using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    protected float _speed;

    private bool isVisible = false;
    private SpriteRenderer childSprite;

    void Awake()
    {
        childSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void OnEnable()
    {
        GetComponentInChildren<SpriteRenderer>().flipX = false;
        _speed = speed;
        CheckSide();
    }

    void Update()
    {
        Movement();
        WhereAmI();
        IAmReadytoDestroy();
    }

    private void CheckSide()
    {
        if (transform.position.x > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            _speed *= -1;
        }
    }

    private void Movement()
    {
        transform.position = new Vector2(transform.position.x + (_speed * Time.deltaTime), transform.position.y);
    }

    private void WhereAmI()
    {
        if (childSprite.isVisible)
        {
            isVisible = true;
        }
    }

    public virtual void IAmReadytoDestroy()
    {
        if (isVisible == true && childSprite.isVisible == false)
        {
            gameObject.SetActive(false);
            isVisible = false;
        }
    }
}