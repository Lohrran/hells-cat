using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultControl : MonoBehaviour
{
    private GameObject spawnEnemy;
    private GameObject[] containerEnemy;
    private Container[] enemiesWeight;
    void Awake()
    {
        spawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy");
        containerEnemy = new GameObject[spawnEnemy.transform.childCount];
        for (int i = 0; i < spawnEnemy.transform.childCount; i++)
        {
            containerEnemy[i] = spawnEnemy.transform.GetChild(i).gameObject;
        }

        enemiesWeight = new Container [containerEnemy[0].GetComponent<Container>().spawnList.Length];

        for (int i = 0; i < enemiesWeight.Length; i++)
        {
            enemiesWeight[i] = containerEnemy[i].GetComponent<Container>();
        }
    }

	void Update ()
    {
	    Control();
	}

    void Control ()
    {
        if (Properties.Instance.GetScore() <= 10)
        {
            //easiest
            for (int i = 0; i < enemiesWeight.Length; i++)
            {
                Properties.Instance.SetSpawnTime (1f);
                Properties.Instance.SetEnemiesScreenQtd (10);
                enemiesWeight[i].spawnList[0].weight = 20;
                enemiesWeight[i].spawnList[1].weight = 1;
                enemiesWeight[i].spawnList[2].weight = 1;
                enemiesWeight[i].spawnList[3].weight = 1;
            }
        }

        else if (Properties.Instance.GetScore() > 10 && Properties.Instance.GetScore() <= 20)
        {
            //easier
            for (int i = 0; i < enemiesWeight.Length; i++)
            {
                Properties.Instance.SetSpawnTime (.8f);
                Properties.Instance.SetEnemiesScreenQtd (15);
                enemiesWeight[i].spawnList[0].weight = 10;
                enemiesWeight[i].spawnList[1].weight = 2;
                enemiesWeight[i].spawnList[2].weight = 1;
                enemiesWeight[i].spawnList[3].weight = 1;
            }
        }

        else if (Properties.Instance.GetScore() > 20 && Properties.Instance.GetScore() <= 30)
        {
            //easy
            for (int i = 0; i < enemiesWeight.Length; i++)
            {
                Properties.Instance.SetSpawnTime (.6f);
                Properties.Instance.SetEnemiesScreenQtd (20);
                enemiesWeight[i].spawnList[0].weight = 10;
                enemiesWeight[i].spawnList[1].weight = 3;
                enemiesWeight[i].spawnList[2].weight = 2;
                enemiesWeight[i].spawnList[3].weight = 1;
            }
        }

        else if (Properties.Instance.GetScore() > 30 && Properties.Instance.GetScore() <= 40)
        {
            //medium
            for (int i = 0; i < enemiesWeight.Length; i++)
            {
                Properties.Instance.SetSpawnTime (.5f);
                Properties.Instance.SetEnemiesScreenQtd (30);
                enemiesWeight[i].spawnList[0].weight = 8;
                enemiesWeight[i].spawnList[1].weight = 4;
                enemiesWeight[i].spawnList[2].weight = 2;
                enemiesWeight[i].spawnList[3].weight = 2;
            }
        }

        else if (Properties.Instance.GetScore() > 40 && Properties.Instance.GetScore() <= 50)
        {
            //hard
            for (int i = 0; i < enemiesWeight.Length; i++)
            {
                Properties.Instance.SetSpawnTime (.5f);
                Properties.Instance.SetEnemiesScreenQtd (30);
                enemiesWeight[i].spawnList[0].weight = 4;
                enemiesWeight[i].spawnList[1].weight = 6;
                enemiesWeight[i].spawnList[2].weight = 2;
                enemiesWeight[i].spawnList[3].weight = 3;
            }
        }

        else if (Properties.Instance.GetScore() > 50 && Properties.Instance.GetScore() <= 60)
        {
            //harder
            for (int i = 0; i < enemiesWeight.Length; i++)
            {
                Properties.Instance.SetSpawnTime (.5f);
                Properties.Instance.SetEnemiesScreenQtd (40);
                enemiesWeight[i].spawnList[0].weight = 2;
                enemiesWeight[i].spawnList[1].weight = 8;
                enemiesWeight[i].spawnList[2].weight = 3;
                enemiesWeight[i].spawnList[3].weight = 4;
            }
        }

        else if (Properties.Instance.GetScore() > 60 && Properties.Instance.GetScore() <= 70)
        {
            //hardest
            for (int i = 0; i < enemiesWeight.Length; i++)
            {
                Properties.Instance.SetSpawnTime (.5f);
                Properties.Instance.SetEnemiesScreenQtd (50);
                enemiesWeight[i].spawnList[0].weight = 4;
                enemiesWeight[i].spawnList[1].weight = 10;
                enemiesWeight[i].spawnList[2].weight = 2;
                enemiesWeight[i].spawnList[3].weight = 5;
            }
        }

        else if (Properties.Instance.GetScore() > 70)
        {
            //hell
            //if(to each 10 second get +1 harder)
            for (int i = 0; i < enemiesWeight.Length; i++)
            {
                Properties.Instance.SetSpawnTime (.5f);
                Properties.Instance.SetEnemiesScreenQtd (60);
                enemiesWeight[i].spawnList[0].weight = 2;
                enemiesWeight[i].spawnList[1].weight = 10;
                enemiesWeight[i].spawnList[2].weight = 2;
                enemiesWeight[i].spawnList[3].weight = 8;
            }
        }
    }
}
