using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoRap : MonoBehaviour
{
    public GameObject player;

    float speed = 0.15f;

    float timerSelfDestruct = 0;
    float timerSelfDestruct_Max = 5;

    // Start is called before the first frame update
    void Start()
    {
        timerSelfDestruct = Time.time;

        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;

        if (Time.time >= timerSelfDestruct + timerSelfDestruct_Max)
        {
            Destroy(gameObject);

            timerSelfDestruct = Time.time;
        }
    }
}
