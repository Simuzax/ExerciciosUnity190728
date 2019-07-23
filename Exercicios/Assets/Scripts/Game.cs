using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Timers;
using TMPro;

public class Game : MonoBehaviour
{
    private GameObject inimigoPrefab;

    public GameObject inimigoRap;
    public GameObject inimigoLent;
    public GameObject inimigoZigzag;
    public GameObject inimigoRanged;

    public TextMeshProUGUI textoScore;

    [SerializeField]
    TimersManager timeManager;

    Color32 cor = new Color32(217, 111, 17, 255);
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

    void changeColor()
    {
        cor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
    }

    // Start is called before the first frame update
    void Start()
    {
        inimigoPrefab = inimigoRanged;

        TimersManager.SetLoopableTimer(this, enemyTimeRate, spawnInimigo);
        TimersManager.SetLoopableTimer(this, scoreTimeRate, scoreRate);
        //----------
        TimersManager.SetTimer(this,scoreTimer);
        TimersManager.ClearTimer(EmptyTimer);
        //----------
        TimersManager.SetLoopableTimer(this, 0.15f, changeColor);

        lastDamageTakenTime = Time.time;
    }

    static void EmptyTimer() { }

    // Update is called once per frame
    void Update()
    {   
        textoScore.text = "SCORE: " + pontuação;
        textoScore.color = cor;

        if (Input.GetKeyDown(KeyCode.R))
        {
            TimersManager.ClearTimer(spawnInimigo);
            TimersManager.ClearTimer(scoreRate);
            TimersManager.ClearTimer(changeColor);

            Destroy(timeManager);

            SceneManager.LoadScene(0);
        }
    }
}
