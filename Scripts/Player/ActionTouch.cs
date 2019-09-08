using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTouch : MonoBehaviour 
{
	void Update ()
    {
        if (Properties.Instance.canvas != Assortment.Paused)
        {
            Interaction();
        }
	}

    void Interaction()
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

                else if (hit.collider.GetComponent<Pickup>() != null)
                {
                    hit.collider.GetComponent<Pickup>().SetPowerUp();
                }
            }
        }
    }
}
