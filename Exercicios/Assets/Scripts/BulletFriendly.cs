using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFriendly : MonoBehaviour
{
    float speed = 5f;

    [SerializeField]
    Vector3 direction = new Vector3(0, 0, 1);

    float timerSelfDestruct = 0;
    float timerSelfDestruct_Max = 5;

    // Start is called before the first frame update
    void Start()
    {
        timerSelfDestruct = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime,Space.World);
    
        if (Time.time >= timerSelfDestruct + timerSelfDestruct_Max)
        {
            Destroy(gameObject);
            
            timerSelfDestruct = Time.time;
        }
    }

    public void setDirection(Vector3 dir)
    {
        direction = dir;

        Quaternion rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
        }
    }
}
