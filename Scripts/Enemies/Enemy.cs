using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
    public float speed;
    public float weight;

    protected int damage;
    protected Animator anim;
    protected GameObject coin;
    protected BoxCollider2D box;

    [HideInInspector]
    public float _speed;

    void OnEnable()
    {
        damage = life;
        _speed = speed;
        box.enabled = true;
    }

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Ability();
        Behind();
        Dead();
        Movement();
        Crossed();
    }

    private void Movement()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (_speed * Time.deltaTime));
    }

    private void Crossed()
    {
        if (transform.position.y <= CameraBoundariesExtension.Instance.minY - 1)
        {
            if (Properties.Instance.GetAssortment() != Assortment.GameOver)
            {
                Properties.Instance.SetAssortment(Assortment.GameOver);
                gameObject.SetActive(false);
            }
        }
    }

    protected virtual void Ability()
    {

    }

    public virtual void Reaction()
    {
        AudioManager.Instance.Play("Enemy Dead");
        damage = damage - 1;
    }

    public virtual void Damage()
    {
        damage = damage - life;
        AudioManager.Instance.Play("Enemy Dead");
    }

    protected virtual void Dead()
    {
        if (damage <= 0)
        {
            anim.SetTrigger("died");
            _speed = 0;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dead") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Coin();
            gameObject.SetActive(false);

        }

        if (Properties.Instance.canvas == Assortment.GameOver)
        {
            gameObject.SetActive(false);
        }
    }

    private void Behind()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1f;

        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D[] hits = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(position, direction, hits, distance);

        if (damage > 0)
        {
            if (hits[1].collider != null && hits[1].collider.gameObject.tag == "Enemy")
            {
                if (hits[1].collider.gameObject.GetComponent<Enemy>().damage > 0)
                {
                    float tempS = hits[1].collider.gameObject.GetComponent<Enemy>()._speed;

                    if (this._speed > tempS)
                    {
                        _speed = tempS;
                    }
                }
            }
            else
            {
                _speed = speed;
            }
        }
    }

    protected void Coin()
    {
        coin = ObjectPooler.SharedInstance.GetPooledGameObject("Coin");
        if (coin != null)
        {
            coin.transform.position = new Vector2(transform.position.x, transform.position.y);
            coin.SetActive(true);
        }
    }

    public void OffBox()
    {
        box.enabled = false;
    }
}
