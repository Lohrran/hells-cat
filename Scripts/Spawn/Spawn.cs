using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnRate;

    public GameObject[] containers;

    protected IEnumerator coroutine;

    protected int index;
    protected int temp;

    void Awake()
    {
        containers = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            containers[i] = transform.GetChild(i).gameObject;
        }
    }

    void Start()
    {   
        _Start();
    }
    protected virtual void _Start()
    {
        coroutine = SpawnConteiners(spawnRate);
        StartCoroutine(coroutine);
    }

    protected virtual IEnumerator SpawnConteiners (float wait)
    {
        while (Properties.Instance.GetAssortment() != Assortment.Paused && Properties.Instance.GetAssortment() != Assortment.GameOver)
        {
            index = Random.Range(0, containers.Length);
            containers[index].GetComponent<Container>().DecideSpawnable();
            if (index != temp)
            {
                containers[index].GetComponent<Container>().Spawn();
                temp = index;
            }

            yield return new WaitForSeconds(wait);
        }
    }
}
