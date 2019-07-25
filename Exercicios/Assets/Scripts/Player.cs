using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI textoHp;

    public float speed = 50f;
    double hp;

    [SerializeField]
    bool isPlayerOne;

    [SerializeField]
    CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        TimersManager.SetLoopableTimer(this, 5f, hpRegen);
    }

    // Update is called once per frame
    void Update()
    {
        textoHp.text = "HP: " + hp;

        walkP1();
    }

    void walkP1()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed;

        Vector3 moveAmount = velocity * Time.deltaTime;

        transform.Translate(moveAmount);
    }

    void hpRegen()
    {
        hp += 50;
    }
}
