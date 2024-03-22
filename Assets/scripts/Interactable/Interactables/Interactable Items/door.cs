using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : Interactable
{

    [SerializeField] Animator animator;
    protected override void Interact()
    {
        if(GameManager.Instance.haveKey)
        {
            animator.SetBool("doorOpen", true);
        }
        else
        {
            UiManager.instance.UpdateInfoText("Find door key.");
        }
        
    }
}
