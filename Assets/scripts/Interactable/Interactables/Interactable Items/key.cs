using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : Interactable
{
    protected override void Interact()
    {
        GameManager.Instance.haveKey = true;
        Destroy(this.gameObject);
    }
}
