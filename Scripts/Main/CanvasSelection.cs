using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelection : MonoBehaviour
{
    private GameObject[] _canvas;

    void Awake()
    {
        _canvas = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _canvas[i] = transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        Selection();
        CanvasFunction();
    }

    private void Selection()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (_canvas[i].gameObject.tag == Properties.Instance.canvas.ToString())
            {
                _canvas[i].gameObject.SetActive(true);
            }

            else
            {
                _canvas[i].gameObject.SetActive(false);
            }
        }
    }

    private void CanvasFunction()
    {
        switch (Properties.Instance.canvas)
        {
            case Assortment.Unpaused:
                Time.timeScale = 1;
                break;
            case Assortment.Paused:
                Time.timeScale = 0;
                break;
            case Assortment.GameOver:
                if (Properties.Instance.GetScore() > SaveData.Instance.GetHighscore())
                {                    
                    //AdManager.Instance.GetAd();
                    SaveData.Instance.SetHighscore(Properties.Instance.GetScore());
                    SaveData.Instance.Save();
                }
                break;
        }
    }
}
