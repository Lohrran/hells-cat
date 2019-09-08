using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Assortment
{
    Unpaused,
    Paused,
    GameOver
}

public class Properties : MonoBehaviour
{
    public Assortment canvas;

    public int score;
    public float spawnTime;
    public int enemiesScreenQtd;

    private static Properties instance;

    public static Properties Instance { get { return instance; } }

    void Awake ()
    {
        canvas = Assortment.Unpaused;

        if (instance == null)
        {
            instance = this;
        }
   
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public int Add_Score (int qtd)
    {
        score = score + qtd;
        return score;
    }

    public int GetScore ()
    {
        return score;
    }

    public void Reset_Score()
    {
        score = 0;
    }

    public float SetSpawnTime (float qtd)
    {
        return spawnTime = qtd;
    }

    public float GetSpawnTime ()
    {
        return spawnTime;
    }

    public int SetEnemiesScreenQtd (int qtd)
    {
        return enemiesScreenQtd = qtd;
    }

    public int GetEnemiesScreenQtd ()
    {
        return enemiesScreenQtd;
    }

    public Assortment SetAssortment (Assortment _status)
    {
        return canvas = _status;
    }
    public Assortment GetAssortment()
    {
        return canvas;
    }
}

