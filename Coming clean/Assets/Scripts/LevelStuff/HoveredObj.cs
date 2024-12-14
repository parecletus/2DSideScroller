using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hovered : MonoBehaviour
{
    public Animator animator;
    public AnimationClip anim;

    void Start(){
        animator.Play(anim.name);
    }
    
}
