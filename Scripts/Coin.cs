using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator anim;

    void Awake ()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update ()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("coin") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Properties.Instance.Add_Score(1);
            AudioManager.Instance.Play("Coin Collected");
            gameObject.SetActive(false);
        }
    }
	
}
