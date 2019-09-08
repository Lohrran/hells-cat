using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : PowerUp
{
    protected override void Power()
    {
        base.Power();
        Time.timeScale = 0.5f;
    }
}
