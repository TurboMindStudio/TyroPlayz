using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphabetBox : Interactable
{
    [SerializeField] PickUp pickUp;
    protected override void Interact()
    {
        pickUp.pickItem();
    }
}
