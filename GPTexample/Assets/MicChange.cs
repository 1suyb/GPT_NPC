using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class MicChange : MonoBehaviour
{
    public GameObject buttonprefab;
    public VoiceRecording voiceRecording;
    public bool isfirst = true;
    public void MicSetting()
    {
        if(isfirst) {
            isfirst= false;
            this.gameObject.SetActive(true);
            foreach (string device in Microphone.devices)
            {
                GameObject button = GameObject.Instantiate(buttonprefab, this.transform);
                button.GetComponentInChildren<TextMeshProUGUI>().text = device;
                button.GetComponent<Button>().onClick.AddListener(() => voiceRecording.setMic(device));
            }
            return;
        }
        if (this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

    }
}
