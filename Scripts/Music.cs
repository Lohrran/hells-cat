using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	void Update ()
    {
        AudioManager.Instance.Play("Music");
    }
}
