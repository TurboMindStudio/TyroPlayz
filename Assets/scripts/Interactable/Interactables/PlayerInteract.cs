using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public LayerMask mask;
    [SerializeField] float distance;
    private PlayerUi playerUi;
    private RaycastHit hit;
    public GameObject InteractableButton;
    public Outline[] outline;
    private void Start()
    {
        playerUi = GetComponent<PlayerUi>();
       
    }


    private void Update()
    {
        playerUi.UpdateText(string.Empty);
        Ray ray=new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance, mask))
        {
            if(hit.collider.GetComponent<Interactable>()!=null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                playerUi.UpdateText(interactable.promptMsg);
                InteractableButton.SetActive(true);

                Outline outline = hit.collider.GetComponent<Outline>();
                outline.enabled = true;
                //Windows
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.baseInteract();
                }
               
            }
        }
        else
        {
            InteractableButton.SetActive(false);
            UiManager.instance.UpdateInfoText(string.Empty);

            foreach (Outline ItemOutline in outline)
            {
                ItemOutline.enabled = false;
            }
        }

    }

    public void Interactable()
    {

        playerUi.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                playerUi.UpdateText(interactable.promptMsg);
           
                interactable.baseInteract();
                

            }
        }
        

    }
}
