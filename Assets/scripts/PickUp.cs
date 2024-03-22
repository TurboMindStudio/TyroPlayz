using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    
    
    public GameObject pickUpItem;
    public GameObject ItemPickPosition;
    public GameObject equipmentSlot;
    public PlayerInteract playerInteract;
    public bool isHolding;
    public bool isThrow;
    public Button throwButton;
    public Vector3 machineRot;
    private void Start()
    {
        throwButton.onClick.AddListener(throwItem);
    }

    private void Update()
    {
        if(isHolding==true)
        {
            
            PIckupManager.Instance.slotFull = true;
            pickUpItem.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pickUpItem.GetComponent<Rigidbody>().useGravity = false;
            pickUpItem.GetComponent<Outline>().enabled = true;
            pickUpItem.transform.SetParent(ItemPickPosition.transform);
            pickUpItem.transform.localPosition = Vector3.zero;
            this.gameObject.GetComponent<Collider>().enabled = false;
            //pickUpItem.transform.localScale = new Vector3(120, 120, 120);
            //pickUpItem.transform.localRotation = Quaternion.Euler(machineRot);

        }

        if(isThrow == true)
        {
            isThrow = false;

            if (isHolding == true)
            {
                PIckupManager.Instance.slotFull = false;
                isHolding = false;
                pickUpItem.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Collider>().enabled = true;
                pickUpItem.GetComponent<Outline>().enabled = false;
                pickUpItem.transform.SetParent(equipmentSlot.transform);
            }
            
            
        }
       
    }
    public void pickItem()
    {
        if (PIckupManager.Instance.slotFull == false)
            isHolding = true;
           PIckupManager.Instance.throwButton.SetActive(true);
           playerInteract.InteractableButton.SetActive(false);
    }

    public void throwItem()
    {
        isThrow = true;
        PIckupManager.Instance.throwButton.SetActive(false);
    }

    


}
