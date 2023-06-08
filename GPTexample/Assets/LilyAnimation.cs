using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyAnimation : MonoBehaviour
{
    public readonly string[] animations = {
        "Walking",
        "JoyfulJump",
        "Dancing",
        "Greeting",
        "Angry" 
    };

    enum Animations
    {
        Walking = 0,
        JoyfulJump = 1,
        Dancing = 2,    
        Greeting = 3,
        Angry = 4
    };
    private Animator animator;


    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void startWalking()
    {
        animator.SetBool(animations[(int)Animations.Walking], true);
    }
    public void startDancing()
    {
        animator.SetBool(animations[(int)Animations.Dancing], true);
    }
    public void startGreeting() {
        animator.SetBool(animations[(int)Animations.Greeting], true);
    }
    public void startAngry() {
        animator.SetBool(animations[(int)Animations.Angry], true);
    }
    public void startJoyfulJump() {
        animator.SetBool(animations[(int)Animations.JoyfulJump], true);
    }
    public void endWalking() { 
        animator.SetBool(animations[(int)Animations.Walking], false);
    }
    public void endDancing() { 
        animator.SetBool(animations[(int)Animations.Dancing], false);
    }
    public void endGreeting() { 
        animator.SetBool(animations[(int)Animations.Greeting], false);
    }
    public void endAngry() { 
        animator.SetBool(animations[(int)Animations.Angry], false);
    }
    public void endJoyfulJump() {
        animator.SetBool(animations[(int)Animations.JoyfulJump], false);

    }

}
