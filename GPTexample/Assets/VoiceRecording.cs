using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;


public class VoiceRecording : MonoBehaviour
{
    public delegate void sendVoicePacket(string name, List<float[]> data);
    public delegate void receivePacket();
    public sendVoicePacket send;
    public receivePacket recv;

    public UnityEvent Action;
    public UnityEvent Response;

    [SerializeField] AudioSource aud;
    [SerializeField] List<AudioClip> _clips;
    List<float[]> samples;
    string _microPhoneDevice;
    Coroutine _recordingCoroutine;
    bool _isRecording = false;

    private void Start()
    {
        send = this.GetComponent<ServerManager>().SendVoicePacket;
        recv = this.GetComponent<ServerManager>().ReceiveMassagePacket;
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        _clips = new List<AudioClip>();
        samples = new List<float[]>();
    }

    public void StartRecored()
    {
        print("start record");
        _isRecording = true;
        _clips.Clear();
        samples.Clear();
        _recordingCoroutine = StartCoroutine(Recording());
    }

    public List<float[]> EndRecording()
    {
        if(_isRecording)
        {
            Debug.Log("¿Ã¿Ã¿◊");
            _isRecording = false;
            StopCoroutine(_recordingCoroutine);
            Microphone.End(_microPhoneDevice);
            for (int i = 0; i< _clips.Count; i++)
            {
                float[] sample = new float[_clips[i].samples * _clips[i].channels];
                _clips[i].GetData(sample, 0);
                samples.Add(sample);
            }
            return samples;
        }
        return null;
    }

    public void SendVoice(string name)
    {
        send.Invoke(name, samples);
        recv.Invoke();
    }

    IEnumerator Recording()
    {
        while(true)
        {
            Debug.Log("¿◊");
            _clips.Add(Microphone.Start(_microPhoneDevice, false, 10, 16000));
            yield return new WaitForSeconds(10f);
        }
    }

    public void setMic(string device)
    {
        print(device);
        _microPhoneDevice = device;
    }

}
