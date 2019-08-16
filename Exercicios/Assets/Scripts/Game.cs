using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Timers;
using TMPro;

public class Game : MonoBehaviour
{
    public GameObject powerUp;

    public GameObject[] inimigos;

    public TextMeshProUGUI textoScore;

    [SerializeField]
    TimersManager timeManager;

    double pontuação;

    float powerUpTimeRate = 10f;
    float enemyTimeRate = 2f;
    float scoreTimeRate = 0.5f;

    float time;
    Timer scoreTimer = new Timer(Timer.INFINITE, Timer.INFINITE, EmptyTimer);
    float lastDamageTakenTime;

    Vector3 getRandomSpawnPosition()
    {
        return new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10));
    }

    void spawnInimigo()
    {
        GameObject go = Instantiate(inimigos[Random.Range(0, inimigos.Length)], getRandomSpawnPosition(), Quaternion.identity);
    }

    void spawnPowerUp()
    {
        Instantiate(powerUp, new Vector3(Random.Range(0, 10), 1, 0), Quaternion.identity);
    }

    void scoreRate()
    {
        if (time < 100)
            pontuação++;
        else if (time > 100 && time < 200)
            pontuação += 2;
        else if (time > 200) pontuação += 3;

        time += scoreTimeRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        TimersManager.SetLoopableTimer(this, enemyTimeRate, spawnInimigo);
        TimersManager.SetLoopableTimer(this, scoreTimeRate, scoreRate);
        TimersManager.SetLoopableTimer(this, powerUpTimeRate, spawnPowerUp);
        //----------
        TimersManager.SetTimer(this,scoreTimer);
        TimersManager.ClearTimer(EmptyTimer);

        lastDamageTakenTime = Time.time;
    }

    static void EmptyTimer() { }

    // Update is called once per frame
    void Update()
    {   
        textoScore.text = "SCORE: " + pontuação;

        if (Input.GetKeyDown(KeyCode.R))
        {
            TimersManager.ClearTimer(spawnInimigo);
            TimersManager.ClearTimer(scoreRate);
            TimersManager.ClearTimer(spawnPowerUp);

            Destroy(timeManager);

            SceneManager.LoadScene(0);
        }
    }
}
