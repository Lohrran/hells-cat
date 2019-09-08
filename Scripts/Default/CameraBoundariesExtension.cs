using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundariesExtension : MonoBehaviour
{
	private Vector3 min;
	private Vector3 max;

	[HideInInspector] public float minX;
	[HideInInspector] public float maxX;

	[HideInInspector] public float minY;
	[HideInInspector] public float maxY;


    private static CameraBoundariesExtension instance;

    public static CameraBoundariesExtension Instance { get { return instance; } }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    void Start () 
	{
		min = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		max = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));

		minX = min.x;
		maxX = max.x;

		minY = min.y;
		maxY = max.y;
	}
}
