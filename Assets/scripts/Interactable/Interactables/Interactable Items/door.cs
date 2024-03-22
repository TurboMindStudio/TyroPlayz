using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : Interactable
{

    [SerializeField] Animator animator;
    protected override void Interact()
    {
        animator.SetBool("doorOpen", true);
    }
}
