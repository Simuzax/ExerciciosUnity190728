using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class InimigoRanged : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;

    float timerSelfDestruct = 0;
    float timerSelfDestruct_Max = 5;

    // Start is called before the first frame update
    void Start()
    {
        timerSelfDestruct = Time.time;

        if (!player || player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        TimersManager.SetLoopableTimer(this, 2f, shootAt);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        if (Time.time >= timerSelfDestruct + timerSelfDestruct_Max)
        {
            Destroy(gameObject);

            timerSelfDestruct = Time.time;
        }
    }


    void shootAt()
    {
        Vector3 instantiatePosition = transform.position + new Vector3(0, 0, 1);
        instantiatePosition.y = player.transform.position.y;

        GameObject go = Instantiate(bullet, instantiatePosition, Quaternion.identity);
    }
}
