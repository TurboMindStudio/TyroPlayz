using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompText;
    void Start()
    {
        
    }

    public void UpdateText(string promtMsg)
    {
        prompText.text= promtMsg;
    }
}
