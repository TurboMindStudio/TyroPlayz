using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckupManager : MonoBehaviour
{
    public static PIckupManager Instance;
    public bool slotFull;
    public bool ItemPicked;
    public bool isthrow;
    public GameObject throwButton;
    private void Awake()
    {
        Instance = this;
        
    }
    public void throwItem()
    {
        isthrow = true;
        slotFull = false;
        ItemPicked = false;
    }
}
