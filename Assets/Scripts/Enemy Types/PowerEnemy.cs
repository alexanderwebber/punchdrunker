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

        EnemyTree = BuildTree();
    }

    void StraightShot()
    {
        float accuracyFactor = ChanceGenerator();

        // 85% Chance Hit
        if (accuracyFactor >= 0.15)
        {
            //PlayerObject.currentHP -= (0.1 * EnemyPower); 
            Debug.Log("Player got hit by Straight Shot!");
            TurnCount++;
        }
        else
            TurnCount++;
            Debug.Log("Player dodged Straight Shot!");
    }

    void AbsoluteUnit()
    {
       int NewEnemyPower = (int) 1.1 * EnemyPower;
    }

    void MegaRightHook()
    {
        float accuracyFactor = ChanceGenerator();

        // 60% Chance Hit
        if (accuracyFactor >= 0.4)
        {
            //PlayerObject.currentHP -= (0.15 * EnemyPower); 
            Debug.Log("Player got hit by Mega Right Hook!");
            TurnCount++;
        }
        else
            TurnCount++;
        Debug.Log("Player dodged Straight Shot!");
    }

    void HatefulPunch()
    {
        float accuracyFactor = ChanceGenerator();

        // 30% Chance Hit
        if (accuracyFactor >= 0.7)
        {
            //PlayerObject.currentHP -= (0.2 * EnemyPower); 
            Debug.Log("Player got hit by Hateful Punch!");
            TurnCount++;
        }
        else
            TurnCount++;
        Debug.Log("Player dodged Hateful Punch!");
    }
}
