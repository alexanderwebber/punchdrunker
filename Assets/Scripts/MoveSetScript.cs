using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// Unless denoted by a commented out link, TK wrote literally everything here

public class MoveSetScript : MonoBehaviour
{
    public EnemyObject enemy;
    public PlayerObject player;
    public MatchTurn turn;
    public Animator anime;
    public Animator player_anime;

    int[] moveSetDMG = new int[11];
    int[] moveSetCost = new int[11];

    // -----------------------------------------------------------------------//

    /*
     * LIST OF MOVES POSSIBLE:
     * 0 Counter
     * 1 Jab
     * 2 Straight / Light Attack
     * 3 Hook / Heavy Attack
     * 4 Sunday Punch / Crit chance
     * 5 Dynamite Blow / Dazes enemy
     * 6 Guard / Halves Damage 1 turn
     * 7 Recover / +% of HP & SP
     * 8 ButterBee +EVA for 3 turns, does not stack
     * 9 Miss / Missed Oponent
     * 10 Dazed / Dazed by enemy cannot attack
     */

    // -----------------------------------------------------------------------//

    // Start is called before the first frame update
    void Start()
    {
        setUpMoveSet();
    }

    public void setUpMoveSet()
    {
        moveSetDMG[0] = 20; // counter base damage
        moveSetDMG[1] = 5; // jab
        moveSetDMG[2] = 15; // straight / light
        moveSetDMG[3] = 25; // hook / heavy
        moveSetDMG[4] = 30; // sunday
        moveSetDMG[5] = 40; // dynamite
        moveSetDMG[6] = 0; // guard
        moveSetDMG[7] = 0; // recover
        moveSetDMG[8] = 0; // butterbee
        moveSetDMG[9] = 0; // miss
        moveSetDMG[10] = 0; // dazed

        moveSetCost[0] = 8; // counter
        moveSetCost[1] = 0; // jab
        moveSetCost[2] = 4; // straight /light
        moveSetCost[3] = 8; // hook / heavy
        moveSetCost[4] = 12; // sunday
        moveSetCost[5] = 12; // dynamite
        moveSetCost[6] = 4; // guard
        moveSetCost[7] = 8; // recover
        moveSetCost[8] = 12; // butterbee
        moveSetCost[9] = 0; // miss
        moveSetCost[10] = 0; // dazed
    }

    // JJ enemy do move (doMove2)
    public void doMove2(int moveNum)
    {
        // check for valid moveNum 
        // add later incase i add moves rip

        int costSP = getMoveSetCost(moveNum);
        int recSP = getSPrecover(moveNum);
        Debug.Log("before calc recSP = " + recSP);
        int recHP = getHPrecover(moveNum);

        int baseDMG = getMoveBaseDMG(moveNum);
        int attackerDMG = getAdjustedDMG(baseDMG);
        bool guard = getGuard(); // gets if the one recieving move has guard up
        bool evade = getEvade(); // Don added evade

        if (evade)
        {
            attackerDMG = 0;
            Debug.Log("Enemy's attack missed!");
        }

        if (guard) // might decide to have crit ignore guard, when crit exists
        {
            attackerDMG = (int)(attackerDMG / 2);
        }


        if (turn.EnemyTurn)
        {
            Debug.Log("Enemy turn stuff");

            if (moveNum == 6)
            {
                enemy.Guard = true;
            }

            player.HP -= attackerDMG;

            // must prevent spending more SP than have and such
            enemy.SP -= costSP;

            if (enemy.SP + recSP > enemy.MaxSP)
            {
                enemy.SP = enemy.MaxSP;
                Debug.Log("the SP rec is : " + (enemy.MaxSP - enemy.SP));
            }
            else
            {
                enemy.SP += recSP;
                Debug.Log("the SP rec is : " + recSP);
            }

            if (enemy.HP + recHP > enemy.MaxHP)
            {
                enemy.HP = enemy.MaxHP;
                Debug.Log("the HP rec is : " + (enemy.MaxHP - enemy.HP));
            }
            else
            {
                enemy.HP += recHP;
                Debug.Log("the HP rec is : " + recHP);
            }


            // update HP/SP bars
            player.updatePlayerBar();
            enemy.updateEnemyBar();

            // relinquish turn
            turn.PlayerTurn = true;
            turn.EnemyTurn = false;
        }
        /*else
        {
            Debug.Log("it is enemy's turn!");
        }*/

        // UPDATE prevMove with the move that happened (number) (could be a miss or counter)
        anime.SetTrigger("punch_trigger");
    }

    public void doMove(int moveNum)
    {

        //set PrevMove
        player.PrevMove = moveNum;
        // check for valid moveNum 
        // add later incase i add moves rip

        int costSP = getMoveSetCost(moveNum);
        int recSP = getSPrecover(moveNum);
        Debug.Log("before calc recSP = " + recSP);
        int recHP = getHPrecover(moveNum);

        int baseDMG = getMoveBaseDMG(moveNum);
        int attackerDMG = getAdjustedDMG(baseDMG);
        bool guard = getGuard(); // gets if the one recieving move has guard up
        bool evade = getEvade(); // Don added evade

        if (evade)
        {
            attackerDMG = 0;
            Debug.Log("Player's attack missed!");
        }

        if (guard) // might decide to have crit ignore guard, when crit exists
        {
            attackerDMG = (int)(attackerDMG / 2);
        }

        if (turn.PlayerTurn)
        {


            if (moveNum == 6)
            {
                player.Guard = true;
            }

            enemy.HP -= attackerDMG;

                enemy.HP -= attackerDMG;

                // player is prevented from spending more SP than they have elsewhere,
                // enemy must be prevented also in ememy's version of script
                player.SP -= costSP;

                if (player.SP+recSP > player.MaxSP)
                {
                    player.SP = player.MaxSP;
                    Debug.Log("the SP rec is : " + (player.MaxSP - player.SP));
                }
                else
                {
                    player.SP += recSP;
                    Debug.Log("the SP rec is : " + recSP);
                }

                if (player.HP + recHP > player.MaxHP)
                {
                    player.HP = player.MaxHP;
                    Debug.Log("the HP rec is : " + (player.MaxHP - player.HP));
                }
                else
                {
                    player.HP += recHP;
                    Debug.Log("the HP rec is : " + recHP);
                }


                // update HP/SP bars
                player.updatePlayerBar();
                enemy.updateEnemyBar();

            // TK & Ash add hp / KO check
            if (attackerDMG >= enemy.HP)
            {
                enemy.HP = 0;
                Debug.Log("Enemy has been defeated!");

                player.KO = true;
                turn.MatchEnd = true;
                turn.PlayerTurn = false;
                turn.EnemyTurn = false;
            }
            else
            {
                // I'm going to try to move this to Player turn itself
                // relinquish turn
                turn.PlayerTurn = false;
                turn.EnemyTurn = true;
            }
        }

        else
        {
            Debug.Log("it is enemy's turn!");
        }

        // UPDATE prevMove with the move that happened (number) (could be a miss or counter)

        player_anime.SetTrigger("player_punch_trigger");

    }

    // added by Don
    public bool getEvade()
    {
        float EvadeFactor = ChanceGenerator();
        if (turn.PlayerTurn)
        {
            if (EvadeFactor <= enemy.EVA)
                enemy.Evasion = true;
            else
                enemy.Evasion = false;
            return (enemy.Evasion);
        }
        else
        {
            if (EvadeFactor <= player.EVA)
                player.Evasion = true;
            else
                player.Evasion = false;
            return (player.Evasion);
        }
    }

    // added by Don
    public float ChanceGenerator()
    {
        return UnityEngine.Random.Range(0f, 1f);
    }

    public bool getGuard()
    {
        if (turn.PlayerTurn)
        {
            return (enemy.Guard);
        }
        else
        {
            return (enemy.Guard);
        }
    }

    public int getMoveBaseDMG(int moveNum)
    {
        if (moveNum < 6 && moveNum >= 0)
        {
            return moveSetDMG[moveNum];
        }
        else return 0;
    }

    public int getMoveSetCost(int moveNum)
    {
        if (moveNum < 10 && moveNum >= 0)
        {
            Debug.Log("the SP cost is : " + moveSetCost[moveNum]);
            return moveSetCost[moveNum];
        }
        else return -1;
    }

    public int getHPrecover(int moveNum)
    {
        int hpRecover = 0;

        if (turn.PlayerTurn)
        {
            // It is players turn
            hpRecover = (int)(player.REC * player.MaxHP);
        }
        else if (turn.EnemyTurn)
        {
            // It is enemy turn
            hpRecover = (int)(enemy.REC * enemy.MaxHP * 0.90);
        }

        if (moveNum == 0 || moveNum >= 9)
        {
            hpRecover = (int)(hpRecover * 0.5);
        }
        else if (moveNum != 7)
        {
            return 0;
        }

        return hpRecover;
    }

    public int getSPrecover(int moveNum)
    {
        int spRecover = 0;

        if (turn.PlayerTurn)
        {
            // It is players turn
            spRecover = (int)(player.REC * player.MaxSP * 2);
        }
        else if (turn.EnemyTurn)
        {
            // It is enemy turn
            spRecover = (int)(enemy.REC * enemy.MaxSP * 1.85);
        }

        if (moveNum == 0 || moveNum >= 9)
        {

            spRecover = (int)(spRecover * 0.5);
            return spRecover;
        }
        else if (moveNum == 6)
        {
            return spRecover * 2;
        }
        else if (moveNum == 1 || moveNum == 7)
        {
            return spRecover;
        }

        return 0;
    }

    int getAdjustedDMG(int baseDMG)
    {
        // adjusts baseDMG for attackers pwr stat
        // then adjusts damage for defenders tgh stat
        int betterDMG = 0;
        int afterDEF = 0;

        if (turn.PlayerTurn)
        {
            // It is players turn
            betterDMG = (int)(player.DMG * baseDMG);
            afterDEF = (int)(betterDMG * (1 - enemy.DEF));
            Debug.Log("starting damage: " + baseDMG);
            Debug.Log("adjusted for power: " + betterDMG);
            Debug.Log("adjusted for defense: " + afterDEF);
        }
        else if (turn.EnemyTurn)
        {
            // It is enemy turn
            betterDMG = (int)(enemy.DMG * baseDMG);
            afterDEF = (int)(betterDMG * (1 - player.DEF));
        }

        return afterDEF;
    }


    /// /////////////////////////////////////////////////////////////////////////////////////////

    public void testPunchPlayer()
    {
        // moveNum, false=enemyTurn, true=playerTurn
        doMove(0);
        player.HP -= 100;

    }
}
