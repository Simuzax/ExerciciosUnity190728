using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    float speed = 5f;
    Vector3 direction;

    float timerSelfDestruct = 0;
    float timerSelfDestruct_Max = 5;

    // Start is called before the first frame update
    void Start()
    {
        timerSelfDestruct = Time.time;

        GameObject[] alvos = GameObject.FindGameObjectsWithTag("Player");   
        target = alvos[Random.Range(0, alvos.Length)];

        Vector3 input = target.transform.position - transform.position;

        direction = input.normalized;
        
        transform.LookAt(target.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime,Space.World);

        if (Time.time >= timerSelfDestruct + timerSelfDestruct_Max)
        {
            if (Vector3.Distance(transform.position, target.transform.position) >= 30f)
            {
                Destroy(gameObject);
            }
            timerSelfDestruct = Time.time;
        }
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
