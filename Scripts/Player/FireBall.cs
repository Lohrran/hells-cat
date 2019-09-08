using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : PowerUp
{/*
    public float spawnRate;
    private Transform[] containers;
    private IEnumerator coroutine;

    void Awake ()
    {
        containers = new Transform [transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            containers[i] = transform.GetChild(i);
        }
    }

    void Start()
    {
        coroutine = Spawn(spawnRate);
        StartCoroutine(coroutine);
    }

    private IEnumerator Spawn (float wait)
    {
        while (_time > 0 || Properties.Instance.canvas == Assortment.Unpaused)
        {
            int index = Random.Range(0, containers.Length);
            GameObject fireBall = ObjectPooler.SharedInstance.GetPooledGameObject("Fire Ball");
            if (fireBall != null)
            {
                fireBall.transform.position = new Vector2(containers[index].position.x, containers[index].position.y);
                fireBall.SetActive(true);
            }
            yield return new WaitForSeconds(wait);
        }
    }
*/}
