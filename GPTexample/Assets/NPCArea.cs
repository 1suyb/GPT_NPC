using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCArea : MonoBehaviour
{
    [SerializeField] private string npcName;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<InputManager>().MeetNPC(npcName);
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<InputManager>().ByeNPC();
        }
    }
}
