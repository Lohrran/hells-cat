using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class SaveData : MonoBehaviour {

	
	private static SaveData instance;

	public static SaveData Instance 
	{
		get 
		{
			return instance;
		}
	}
	
	[HideInInspector] public int highestscore = 0;
	void Awake()
	{
		//PlayerPrefs.DeleteAll ();
		if (instance == null) 
		{
			instance = this;
		}
		else
		{
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);

		if (PlayerPrefs.HasKey ("High")) 
		{
			//We had a previous session
			highestscore = PlayerPrefs.GetInt ("High");
			
			//PlayerPrefs.Save ();
		}
		else
		{
			Save ();
		}
	}
	
	public void Save ()
	{
		PlayerPrefs.SetInt ("High", highestscore);
		
		PlayerPrefs.Flush ();
		//PlayerPrefs.Save ();
	}

	public int SetHighscore(int newScore)
	{
		highestscore = newScore;
		return highestscore;
	}

	public int GetHighscore()
	{
		return highestscore;
	}
}
