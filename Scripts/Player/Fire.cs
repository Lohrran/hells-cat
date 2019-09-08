using UnityEngine;

public class Fire : Ball
{
    private Animator anim; 

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this._speed = 0f;
            if (gameObject.activeSelf)
            {
                anim.SetTrigger("explosion");
            }
                      
            CameraScreenShake.Instance.Shake(.2f, 4, 2f);
            other.gameObject.GetComponent<Enemy>().Damage();
        }            
    }

    public override void IAmReadytoDestroy()
    {
        base.IAmReadytoDestroy();
        if (gameObject.activeSelf)
        {   
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fire_explosion") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                gameObject.SetActive(false);
            }
        }
    }

   
}
