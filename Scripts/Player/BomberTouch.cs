using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberTouch : PowerUp
{
    public float radius;
    protected override void Power()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = transform.position;
            Collider2D[] hit = Physics2D.OverlapCircleAll(position, radius);

            CameraScreenShake.Instance.Shake(.3f, 6, 3f);

            if (hit.Length > 0)
             {
                 for (int i = 0; i < hit.Length; i++)
                 {
                     hit[i].gameObject.GetComponent<Enemy>().Reaction();
                 }
             }
        }
    }
}
