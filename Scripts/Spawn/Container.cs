using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnableObject
{
    public GameObject prefab;
    public float weight;
}

public class Container : MonoBehaviour
{
    public SpawnableObject[] spawnList;
    private float totalWeight;
    private int index;
    private GameObject gObject;

    void OnValidate()
    {
        totalWeight = 0f;
        foreach(var spawnable in spawnList)
        {
            totalWeight += spawnable.weight;
        }
    }

    void Awake()
    {
        OnValidate();
    }

    public void DecideSpawnable()
    {
        float pick = Random.value * totalWeight;
        index = 0;
        float cumulativeWeight = spawnList[0].weight;

        while(pick > cumulativeWeight && index < spawnList.Length - 1)
        {
            index++;
            cumulativeWeight += spawnList[index].weight;
        }
    }

    public void Spawn()
    {
        gObject = ObjectPooler.SharedInstance.GetPooledGameObject(spawnList[index].prefab.name);
        if (gObject != null)
        {
            gObject.transform.position = new Vector2(transform.position.x, transform.position.y);
            gObject.SetActive(true);
        }
    }
}
