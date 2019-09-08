using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearTouch : PowerUp
{
    protected override void Power()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        AudioManager.Instance.StopAll();
          
        for (int i = 0; i < enemies.Length; i ++)
        {    
            enemies[i].gameObject.GetComponent<Enemy>().Damage();
        }

    }

    void OnDisable()
    {
        AudioManager.Instance.PlayAll();
    }
}
