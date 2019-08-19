using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI playerQuantityIndicator;
    public int playerQuantity = 0;

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
    }

    public void morePlayers()
    {
        if (playerQuantity < 4) playerQuantity++;

        playerQuantityIndicator.text = playerQuantity.ToString();
    }

    public void startGame()
    {
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
