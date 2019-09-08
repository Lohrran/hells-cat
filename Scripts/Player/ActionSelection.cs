using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelection : MonoBehaviour
{
    private GameObject[] actionsChild;
    private float timer;
    private GameObject transition;

    void Awake()
    {
        timer = 1f;

        actionsChild = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i ++)
        {
            actionsChild[i] = transform.GetChild(i).gameObject;
        }
    }
	
	void Update ()
    {
        Selection();
        ActionFunction();
	}

    private void Selection()
    {
        for (int i = 0; i < actionsChild.Length; i ++)
        {
            if (actionsChild[i].name == Action.Instance.GetAction().ToString())
            {
                actionsChild[i].SetActive(true);
            }

            else
            {    
                actionsChild[i].SetActive(false);
            }
        }
    }

    private void ActionFunction ()
    {
        switch (Action.Instance.action)
        {
            case Actions.Transition:
                if (Properties.Instance.GetAssortment() != Assortment.GameOver)
                {   
                    timer = timer - Time.deltaTime;

                    if (timer < 0)
                    {
                        Action.Instance.SetAction (Action.Instance.GetTemp());
                        timer = 1f;
                    }
                }
            break;
        }
    }
}
