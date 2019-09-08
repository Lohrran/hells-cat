using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float time;
    protected float _time;

    void OnEnable()
    {
        _time = time;
    }

    void Update()
    {
        if (Properties.Instance.canvas != Assortment.Paused)
        {
            if (CanIUse())
            {
                Power();
            }
        }
    }

    protected bool CanIUse()
    {
        _time = _time - Time.deltaTime;
        
        if (_time > 0 && Properties.Instance.GetAssortment() != Assortment.GameOver)
        {
            return true;
        }

        else
        {
            Action.Instance.SetTemp(Actions.ActionTouch);
            if (Properties.Instance.GetAssortment() != Assortment.GameOver)
            {
                Action.Instance.SetAction (Actions.Transition);
            }
            return false;
        }
    }

    protected virtual void Power()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, -0.01f);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Enemy>() != null)
                {
                    hit.collider.GetComponent<Enemy>().Reaction();
                }
            }
        }
    }
}
