using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Timers;

public class Game : MonoBehaviour
{
    public GameObject inimigoPrefab;

    double pontuação;
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
        GameObject go = Instantiate(inimigoPrefab, getRandomSpawnPosition(), Quaternion.identity);
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
        //----------
        TimersManager.SetTimer(this,scoreTimer);
        TimersManager.ClearTimer(EmptyTimer);
        TimersManager.SetTimer(this, scoreTimer);

        lastDamageTakenTime = Time.time;
    }

    static void EmptyTimer() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }
}
