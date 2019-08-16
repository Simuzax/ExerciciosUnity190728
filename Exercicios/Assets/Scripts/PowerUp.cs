using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TimersManager.SetLoopableTimer(this, 0.15f, changeColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeColor()
    {
        GetComponent<Renderer>().material.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
    }
}
