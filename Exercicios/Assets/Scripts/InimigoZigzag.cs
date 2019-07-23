using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoZigzag : MonoBehaviour
{
    public GameObject player;

    float speed = 1.5f;

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
