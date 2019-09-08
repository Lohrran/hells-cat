using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttones : MonoBehaviour
{
    public void PauseBn()
    {
        AudioManager.Instance.Play("Button");
        Properties.Instance.SetAssortment(Assortment.Paused);
    }

    public void ContinueBn()
    {
        AudioManager.Instance.Play("Button");
        Properties.Instance.SetAssortment(Assortment.Unpaused);
    }

    public void RestartBn()
    {
        AudioManager.Instance.Play("Button");
        SceneManager.LoadScene("Game");
        Properties.Instance.SetAssortment(Assortment.Unpaused);
        Properties.Instance.Reset_Score();
    }

    public void HomeBn()
    {
        AudioManager.Instance.Play("Button");
        SceneManager.LoadScene("Menu");
        Properties.Instance.SetAssortment(Assortment.Unpaused);
    }

    public void PlayBn()
    {
       // AudioManager.Instance.Play("Button");
        SceneManager.LoadScene("Game");
    }
}
