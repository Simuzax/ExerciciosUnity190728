using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Timers;
using TMPro;
using System.Linq;

public class Game : MonoBehaviour
{
    Menu menu;

    public bool isGameOver;
    public int winner;

    public GameObject panelGameOver;
    public TextMeshProUGUI whoWon;

    public GameObject powerUp;

    public GameObject[] inimigos;
    public GameObject[] players;

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
        return new Vector3(Random.Range(0, 10), 1, 8);
    }

    void spawnInimigo()
    {
        GameObject go = Instantiate(inimigos[Random.Range(0, inimigos.Length)], getRandomSpawnPosition(), Quaternion.identity);
    }

    void spawnPowerUp()
    {
        Instantiate(powerUp, new Vector3(Random.Range(-10, 10), (float)0.5, 0), Quaternion.identity);
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
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        menu.gameObject.SetActive(false);

        for (int i = 0; i < PlayerPrefs.GetInt("playerQuantity"); i++)
        {
            if (i >= players.Length) break;

            Player p = Instantiate(players[i], new Vector3(2 * i, (float)0.5, 0), Quaternion.identity).GetComponent<Player>();

            p.id = i + 1;

            if (PlayerPrefs.GetInt("peopleInTeamOne") > 0)
            {
                p.time = 1;
                PlayerPrefs.SetInt("peopleInTeamOne", PlayerPrefs.GetInt("peopleInTeamOne") - 1);
            }
            else p.time = 2;
        }

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

        if (isGameOver)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void checkWinner()
    {
        GameObject[] time1, time2;

        time1 = System.Array.FindAll(players, x => x.GetComponent<Player>().time == 1);
        time2 = System.Array.FindAll(players, x => x.GetComponent<Player>().time == 2);

        if (System.Array.FindAll(time1, x => x.GetComponent<Player>().Hp <= 0).Length == time1.Length)
        {
            winner = 6;
            isGameOver = true;
        }
        else if (System.Array.FindAll(time2, x => x.GetComponent<Player>().Hp <= 0).Length == time2.Length)
        {
            winner = 5;
            isGameOver = true;
        }

        switch (winner)
        {
            case 1:
                whoWon.text = "PLAYER ONE WON!";
                break;
            case 2:
                whoWon.text = "PLAYER TWO WON!";
                break;
            case 3:
                whoWon.text = "PLAYER THREE WON!";
                break;
            case 4:
                whoWon.text = "PLAYER FOUR WON!";
                break;
            case 5:
                whoWon.text = "TEAM ONE WON!";
                break;
            case 6:
                whoWon.text = "TEAM TWO WON!";
                break;
        }
    }

    public void retryGame()
    {
        SceneManager.LoadScene("Exercicio2");
    }

    public void exitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
