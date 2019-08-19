using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;
using TMPro;

public class Player : MonoBehaviour
{
    public Game gameRef;

    public TextMeshProUGUI textoHp;

    float speed = 5f;
    float speedInicial = 5f;

    float powerUpDuration = 3f;
    double hp = 10;

    Color32 cor, corInicial;

    [SerializeField]
    bool isPlayerOne;

    [SerializeField]
    CharacterController charController;

    Timer powerUp;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        corInicial = GetComponent<Renderer>().material.color;

        powerUp = new Timer(0.1f, (uint)(powerUpDuration / 0.1), absolutelyNotSuperStar);
      
        TimersManager.SetLoopableTimer(this, 5f, hpRegen);
    }

    // Update is called once per frame
    void Update()
    {
        textoHp.text = "HP: " + hp;

        walk();

        if (powerUp.RemainingLoopsCount() <= 0)
        {
            TimersManager.ClearTimer(absolutelyNotSuperStar);
            GetComponent<Renderer>().material.color = corInicial;
            speed = speedInicial;
        }

        if (hp <= 0)
        {
            gameRef.isGameOver = true;

            if (isPlayerOne)
            {
                gameRef.winnerIsPlayerOne = false;
            }
            else
            {
                gameRef.winnerIsPlayerOne = true;
            }

            Destroy(gameObject);
        }

        if (isPlayerOne)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                shootAt();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                shootAt();
            }
        }
    }

    void walk()
    {
        Vector3 input;

        if (isPlayerOne) input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        else input = new Vector3(Input.GetAxisRaw("HorizontalTwo"), 0, Input.GetAxisRaw("VerticalTwo"));

        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed;

        Vector3 moveAmount = velocity * Time.deltaTime;

        transform.Translate(moveAmount);
    }

    void hpRegen()
    {
        hp += 5;
    }

    void absolutelyNotSuperStar()
    {
        speed = 10;
        cor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        GetComponent<Renderer>().material.color = cor;
    }

    void shootAt()
    {
        Vector3 instantiatePosition = transform.position + new Vector3(0, 0, 1);

        GameObject go = Instantiate(bullet, instantiatePosition, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Bullet") || other.transform.CompareTag("Inimigo"))
        {
            hp -= 5;
            Destroy(other.gameObject);
        }

        if (other.transform.CompareTag("PowerUp"))
        {
            powerUp = new Timer(0.1f, (uint)(powerUpDuration / 0.1), absolutelyNotSuperStar);
            TimersManager.SetTimer(this, powerUp);
            Destroy(other.gameObject);
        }
    }   
}
