using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("KEY PROPERTIES")]
    public bool haveKey = false;
    public void Awake()
    {
        Instance = this;
    }
}
