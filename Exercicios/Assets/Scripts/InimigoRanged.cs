using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class InimigoRanged : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        if(!player || player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        TimersManager.SetLoopableTimer(this, 2f, shootAt);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }


    void shootAt()
    {
        Vector3 instantiatePosition = transform.position + new Vector3(0, 0, 1);
        instantiatePosition.y = player.transform.position.y;

        GameObject go = Instantiate(bullet, instantiatePosition, Quaternion.identity);
    }
}
