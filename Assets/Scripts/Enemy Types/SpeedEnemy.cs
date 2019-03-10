using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : EnemyObject
{
    public SpeedEnemy(int hp, int st, int p, int t, int sp) : base(hp, st, p, t, sp)
    {
        enemyMove1 = Unavoidable;
        enemyMove2 = Tireless;
        enemyMove3 = ShutterSpeed;
        enemyMove4 = Evasion;
    }

    void Unavoidable()
    {
        //WIP
    }

    void Tireless()
    {
        //WIP
    }

    void ShutterSpeed()
    {
        //WIP
    }

    void Evasion()
    {
        //WIP
    }

}
