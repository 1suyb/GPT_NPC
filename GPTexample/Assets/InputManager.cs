using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public GameObject recoding;
    public VoiceRecording VoiceRecording;
    public bool meetNPC;
    public string meetNPCName;
    private Vector2 dir;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(dir.x<1)
            {
                dir.x +=1;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (dir.x > -1)
            {
                dir.x -=1;
            }   
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (dir.y > -1)
            {
                dir.y -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (dir.y < 1)
            {
                dir.y += 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (dir.x == 1)
            {
                dir.x -=1;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (dir.x == -1)
            {
                dir.x -= -1;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (dir.y == -1)
            {
                dir.y -= -1;
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (dir.y == 1)
            {
                dir.y -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.F)&& meetNPC)
        {
            recoding.SetActive(true);
            VoiceRecording.StartRecored();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            recoding.SetActive(false);
            VoiceRecording.EndRecording();
            VoiceRecording.SendVoice("¸¶¸°");
        }

    }
    public void FixedUpdate()
    {
        Vector2 nomdir = 0.001f * dir.normalized / Time.fixedDeltaTime;
        this.transform.Translate(new Vector3(0, 0, nomdir.x));
        if (dir.y > 0)
        {
            this.transform.Rotate(new Vector3(0, 0.1f * 1 / Time.fixedDeltaTime, 0));
        }
        if (dir.y < 0)
        {
            this.transform.Rotate(new Vector3(0, 0.1f * -1 / Time.fixedDeltaTime, 0));
        }
    }

    public void MeetNPC(string npc)
    {
        meetNPC= true;
        meetNPCName = npc;
    }
    public void ByeNPC()
    {
        meetNPC= false;
    }
}
