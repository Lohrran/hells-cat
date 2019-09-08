using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Actions
{
    ActionTouch,
    BomberTouch,
    NuclearTouch,
    SlowMotion,
    SpikeWall,
    FireBall,
    Transition,
};

public class Action : MonoBehaviour {

    public Actions action;

    private static Action instance;

    public static Action Instance { get { return instance; } }


    public Actions temp;

    void Awake ()
    {
        action = Actions.ActionTouch;

        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }
    }


    public Actions GetAction()
    {
        return action;
    }

    public Actions SetAction (Actions _action)
    {
        return action = _action;
    }

    public Actions SetTemp (Actions _temp)
    {
        return temp = _temp;
    }

    public Actions GetTemp ()
    {
        return temp;
    }
}
