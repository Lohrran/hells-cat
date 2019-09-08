using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBomb : Enemy
{
    public float radius;

    public override void Reaction()
    {
        this._speed = 0;
        damage = damage - life;
        AudioManager.Instance.Play("Explosion");
        CameraScreenShake.Instance.Shake(.5f, 8, 6f);
    }

    protected override void Dead()
    {
        if (damage <= 0)
        {
            this._speed = 0;

            anim.SetTrigger("explosion");

            Vector2 position = transform.position;
            Collider2D[] hit = Physics2D.OverlapCircleAll(position, radius);

            if (hit.Length > 0)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].gameObject.tag == "Enemy")
                    {
                        hit[i].gameObject.GetComponent<Enemy>().Damage();
                        hit[i].gameObject.GetComponent<Enemy>().OffBox();
                    }
                }
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("explosion") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Coin();
            gameObject.SetActive(false);
        }

        if (Properties.Instance.canvas == Assortment.GameOver)
        {
            gameObject.SetActive(false);
        }
    }

    public override void Damage()
    {
         damage = damage - life;
        AudioManager.Instance.Play("Explosion");
    }

}
