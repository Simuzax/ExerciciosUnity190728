using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class InimigoZigzag : MonoBehaviour
{
    public GameObject player;

    float speed = 0.15f;
    bool direcao = false;

    // Start is called before the first frame update
    void Start()
    {
        TimersManager.SetLoopableTimer(this, 0.5f, rotacionar);

        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
    }

    void rotacionar()
    {
        if (direcao == false)
        {
            transform.Rotate(0, -75, 0, Space.World);

            direcao = true;
        }
        else
        {
            transform.Rotate(0, 75, 0, Space.World);

            direcao = false;
        }
    }
}
