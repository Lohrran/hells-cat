using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWall : PowerUp
{
    void OnTriggerEnter2D(Collider2D other)
    {
        CameraScreenShake.Instance.Shake(.5f, 8, 6f);

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Damage();
            _time = 0;
        } 
    }
}
