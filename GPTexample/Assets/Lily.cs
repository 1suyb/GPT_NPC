using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lily : MonoBehaviour
{

    [SerializeField] ServerManager serverManager;
    [SerializeField] GameObject text;
    [SerializeField]private NPCChat chat;
    private LilyAnimation anim;

    public void Start()
    {
        anim = this.GetComponent<LilyAnimation>();
        chat = this.GetComponentInChildren<NPCChat>();
        serverManager.response = Speak;
        serverManager.action = Action;
    }

    public void Speak(string msg)
    {
        chat.setChat(msg);
    }

    public void Action(string msg)
    {
        switch (msg) 
        {
            case "JoyfulJump":
                anim.startJoyfulJump();
                break;
            case "Dancing":
                anim.startDancing();
                break;
            case "Greeting":
                anim.startGreeting();
                break;
            case "Angry":
                anim.startAngry();
                break;
            default:
                break;
        }
    }

}
