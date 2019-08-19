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

    Color32 cor, corInicial;

    private double hp_;
    public double Hp
    {
        get
        {
            return hp_;
        }
        set
        {
            hp_ = value;
            if (Hp <= 0)
            {
                hp_ = 0;
                gameRef.checkWinner();
                Destroy(gameObject);
            }
        }
    }

    public int id;
    public int time;

    [SerializeField]
    CharacterController charController;

    Timer powerUp;

    public GameObject bullet;

    Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        textoHp = GameObject.Find("HpP" + id).GetComponent<TextMeshProUGUI>();
        gameRef = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();

        corInicial = GetComponent<Renderer>().material.color;

        powerUp = new Timer(0.1f, (uint)(powerUpDuration / 0.1), absolutelyNotSuperStar);
      
        TimersManager.SetLoopableTimer(this, 5f, hpRegen);
    }

    // Update is called once per frame
    void Update()
    {
        textoHp.text = "HP: " + Hp;

        walk();

        if (powerUp.RemainingLoopsCount() <= 0)
        {
            TimersManager.ClearTimer(absolutelyNotSuperStar);
            GetComponent<Renderer>().material.color = corInicial;
            speed = speedInicial;
        }

        switch (id)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    shootAt();
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    shootAt();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    shootAt();
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    shootAt();
                }
                break;
        }
    }

    void walk()
    {
        switch (id)
        {
            case 1:
                input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                break;
            case 2:
                input = new Vector3(Input.GetAxisRaw("HorizontalTwo"), 0, Input.GetAxisRaw("VerticalTwo"));
                break;
            case 3:
                input = new Vector3(Input.GetAxisRaw("HorizontalThree"), 0, Input.GetAxisRaw("VerticalThree"));
                break;
            case 4:
                input = new Vector3(Input.GetAxisRaw("HorizontalFour"), 0, Input.GetAxisRaw("VerticalFour"));
                break;
        }

        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed;

        Vector3 moveAmount = velocity * Time.deltaTime;

        transform.Translate(moveAmount);
    }

    void hpRegen()
    {
        Hp += 5;
    }

    void absolutelyNotSuperStar()
    {
        speed = 10;
        cor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        GetComponent<Renderer>().material.color = cor;
    }

    void shootAt()
    {
        Vector3 instantiatePosition = transform.position + input;

        GameObject go = Instantiate(bullet, instantiatePosition, Quaternion.identity);

        go.GetComponent<BulletFriendly>().setDirection(input);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Bullet") || other.transform.CompareTag("Inimigo"))
        {
            Hp -= 5;
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
