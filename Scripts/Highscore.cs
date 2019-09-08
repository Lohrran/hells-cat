using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
	private Text highscore;

    void Start()
    {
        highscore = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (SaveData.Instance.GetHighscore() != null)
        {
            highscore.text = "" + SaveData.Instance.GetHighscore().ToString();
        }

        else 
        {
            highscore.text = "0";
        }
    }
}
