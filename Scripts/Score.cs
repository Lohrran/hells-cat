using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;

    void Start()
    {
        score = GetComponentInChildren<Text>();
    }

    void Update()
    {
        score.text = "" + Properties.Instance.score;
    }
}
