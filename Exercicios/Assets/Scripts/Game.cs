using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class Game : MonoBehaviour
{
    public GameObject inimigoPrefab;

    void spawnInimigo()
    {
        GameObject go = Instantiate(inimigoPrefab, getRandomSpawnPosition(), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        TimersManager.SetLoopableTimer(this, 2f, spawnInimigo);
    }


    Vector3 getRandomSpawnPosition()
    {
        return new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
