using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOrHighScore : MonoBehaviour 
{
	private GameObject[] scores;
	void Start()
	{
		scores = new GameObject [transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
		{
			scores[i] = transform.GetChild(i).gameObject;
		}

		if (Properties.Instance.GetScore() < SaveData.Instance.GetHighscore())
		{
			scores[0].SetActive(true);
		}

		else
		{
			scores[1].SetActive(true);
		}
	}
	
}
