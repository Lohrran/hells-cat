using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    public float abilityTime;

    private SpriteRenderer sprite;
    private BoxCollider2D _collider;
    private float temp;
    private float temp2;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        temp = abilityTime * 2;
        temp2 = abilityTime;
      
    }

    protected override void Ability()
    {
        temp -= Time.deltaTime;

        if (temp <= 0f)
        {
            sprite.color = new Color(1f, 1f, 1f, .5f);
            _collider.enabled = false;

            temp2 -= Time.deltaTime;
            if (temp2 <= 0)
            {
                temp = 2f;
                temp2 = 2f;
            }
            
        }

        else
        {
            sprite.color = new Color(1f, 1f, 1f, 1f);
            _collider.enabled = true;
        }
  
        
        
  }
}
