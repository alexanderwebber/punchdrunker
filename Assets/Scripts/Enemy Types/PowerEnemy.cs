using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEnemy : EnemyObject
{
    public PowerEnemy(int hp, int st, int p, int t, int sp) : base(hp, st, p, t, sp)
    {
        enemyMove1 = StraightShot;
        enemyMove2 = AbsoluteUnit;
        enemyMove3 = MegaRightHook;
        enemyMove4 = HatefulPunch;

    }

    void StraightShot()
    {

    }

    void AbsoluteUnit()
    {

    }

    void MegaRightHook()
    {

    }

    void HatefulPunch()
    {

    }
}
