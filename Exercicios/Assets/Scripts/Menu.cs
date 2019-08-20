using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI playerQuantityIndicator, teamOneIndicator, teamTwoIndicator;
    public int playerQuantity = 0;

    public int[] time1, time2;

    public int peopleInTeamOne, peopleInTeamTwo;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lessPlayers()
    {
        if (playerQuantity > 0) playerQuantity--;

        playerQuantityIndicator.text = playerQuantity.ToString();

        if (playerQuantity < peopleInTeamOne + peopleInTeamTwo)
        {
            if (peopleInTeamOne > peopleInTeamTwo)
            {
                peopleInTeamOne--;

                teamOneIndicator.text = peopleInTeamOne.ToString();
            }
            else
            {
                peopleInTeamTwo--;

                teamTwoIndicator.text = peopleInTeamTwo.ToString();
            }
        }
    }

    public void morePlayers()
    {
        if (playerQuantity < 4) playerQuantity++;

        playerQuantityIndicator.text = playerQuantity.ToString();
    }

    public void lessTeamOne()
    {
        if (peopleInTeamOne > 0) peopleInTeamOne--;

        teamOneIndicator.text = peopleInTeamOne.ToString();
    }

    public void moreTeamOne()
    {
        if (peopleInTeamOne + peopleInTeamTwo < playerQuantity) peopleInTeamOne++;

        teamOneIndicator.text = peopleInTeamOne.ToString();
    }

    public void lessTeamTwo()
    {
        if (peopleInTeamTwo > 0) peopleInTeamTwo--;

        teamTwoIndicator.text = peopleInTeamTwo.ToString();
    }

    public void moreTeamTwo()
    {
        if (peopleInTeamTwo + peopleInTeamOne < playerQuantity) peopleInTeamTwo++;

        teamTwoIndicator.text = peopleInTeamTwo.ToString();
    }

    public void startGame()
    {
        PlayerPrefs.SetInt("playerQuantity", playerQuantity);
        PlayerPrefs.SetInt("peopleInTeamOne", peopleInTeamOne);
        PlayerPrefs.SetInt("peopleInTeamTwo", peopleInTeamTwo);

        SceneManager.LoadScene("Exercicio3");
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
