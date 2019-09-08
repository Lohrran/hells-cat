using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Ball
{
    public Actions id;

    public void SetPowerUp()
    {
        Action.Instance.SetAction(Actions.Transition);
        Action.Instance.SetTemp (id);
        gameObject.SetActive(false);
    }

}
