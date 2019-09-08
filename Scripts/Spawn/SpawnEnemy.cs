using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : Spawn
{
	private GameObject[] enemiesOnScene;
	protected override void _Start()
	{
		enemiesOnScene = GameObject.FindGameObjectsWithTag ("Enemy");
        
		coroutine = SpawnConteiners(Properties.Instance.GetSpawnTime());
        StartCoroutine(coroutine);
	}

	void Update()
	{
		enemiesOnScene = GameObject.FindGameObjectsWithTag ("Enemy");
	}

	protected override IEnumerator SpawnConteiners (float wait)
	{
		while (Properties.Instance.GetAssortment() != Assortment.Paused && Properties.Instance.GetAssortment() != Assortment.GameOver)
        {
            index = Random.Range(0, containers.Length);
            containers[index].GetComponent<Container>().DecideSpawnable();
            
			if (enemiesOnScene.Length < Properties.Instance.GetEnemiesScreenQtd())
			{
				if (index != temp)
            	{
                	containers[index].GetComponent<Container>().Spawn();
                	temp = index;
            	}
				yield return new WaitForSeconds(Properties.Instance.GetSpawnTime());
			}            
        }
	}
}
