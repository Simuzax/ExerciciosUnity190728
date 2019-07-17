using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = -2f;

    bool x2;
    bool x3;
    bool x4;

    [SerializeField]
    Transform cameraT;

    [SerializeField]
    CharacterController charController;

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }

    void walk()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed;

        Vector3 moveAmount = velocity * Time.deltaTime;

        transform.Translate(moveAmount);
    }
}
