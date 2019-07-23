using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoRap : MonoBehaviour
{
    public GameObject player;

    float speed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
    }
}
