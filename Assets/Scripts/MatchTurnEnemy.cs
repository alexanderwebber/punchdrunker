using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unless denoted by a commented out link, TK wrote literally everything here

public class MatchTurnEnemy : MonoBehaviour
{
    public MatchTurn turn;
    public EnemyObject enemy;
    public PlayerObject player;
    public MoveSetScript moveset;
    public BattleTextScript btext;

    public void doEnemyTurn()
    {
        // TK addition:
        if (enemy.HP <= 0)
        {
            enemy.KO = true;
            turn.MatchEnd = true;
            turn.PlayerTurn = false;
            turn.EnemyTurn = false;
        }
        else
        {
            Debug.Log("You are inside Enemy turn!");

            // If enemy was defending last turn; turn it off
            enemy.Guard = false;

            //JJ's work below

            // this function implements AI to decide which move to take

            Debug.Log("Player's Previous Move: " + player.PrevMove);

            if (player.PrevMove == 4)
            {
                moveset.doMove(7);
                Debug.Log("recover");
            }

            else if (player.PrevMove == 9)
            {
                moveset.doMove(0);
                Debug.Log("counter");
            }

            else if (player.PrevMove == 6)
            {
                if (moveset.getMoveSetCost(4) > player.SP)
                {
                    moveset.doMove2(1);
                    Debug.Log("No SP. Enemy Performs Jab");
                }

                else
                {
                    moveset.doMove2(4);
                    Debug.Log("sunday");
                }
            }

            else
            {

                if (enemy.HP > 157)
                {
                    Debug.Log("enemy hp > 45%");
                    var randNum = Random.Range(0, 100);

                    if (randNum <= 10)
                    {
                        if (moveset.getMoveSetCost(4) > player.SP)
                        {
                            moveset.doMove2(1);
                            Debug.Log("No SP. Enemy Performs Jab");
                        }

                        else
                        {
                            moveset.doMove2(4);
                            Debug.Log("sunday");
                        }
                    }

                    if (randNum > 10 && randNum <= 30)
                    {
                        if (moveset.getMoveSetCost(1) > player.SP)
                        {
                            moveset.doMove2(1);
                            Debug.Log("No SP. Enemy Performs Jab");
                        }

                        else
                        {
                            moveset.doMove2(1);
                            Debug.Log("jab");
                        }
                    }

                    if (randNum > 30 && randNum <= 60)
                    {
                        if (moveset.getMoveSetCost(3) > player.SP)
                        {
                            moveset.doMove2(1);
                            Debug.Log("No SP. Enemy Performs Jab");
                        }

                        else
                        {
                            moveset.doMove2(3);
                            Debug.Log("hook");
                        }
                    }

                    if (randNum > 60 && randNum <= 100)
                    {
                        if (moveset.getMoveSetCost(2) > player.SP)
                        {
                            moveset.doMove2(1);
                            Debug.Log("No SP. Enemy Performs Jab");
                        }

                        else
                        {
                            moveset.doMove2(2);
                            Debug.Log("straight");
                        }
                    }

                }

                if (enemy.HP <= 157)
                {

                    Debug.Log("enemy hp <= .45%");
                    var randNum = Random.Range(0, 100);

                    if (randNum <= 10)
                    {
                        if (moveset.getMoveSetCost(1) > player.SP)
                        {
                            moveset.doMove2(1);
                            Debug.Log("No SP. Enemy Performs Jab");
                        }

                        else
                        {
                            moveset.doMove2(1);
                            Debug.Log("jab");
                        }
                    }

                    if (randNum > 10 && randNum <= 30)
                    {
                        if (moveset.getMoveSetCost(3) > player.SP)
                        {
                            moveset.doMove2(1);
                            Debug.Log("No SP. Enemy Performs Jab");
                        }

                        else
                        {
                            moveset.doMove2(3);
                            Debug.Log("hook");
                        }
                    }

                    if (randNum > 30 && randNum <= 60)
                    {
                        if (moveset.getMoveSetCost(2) > player.SP)
                        {
                            moveset.doMove2(1);
                            Debug.Log("No SP. Enemy Performs Jab");
                        }

                        else
                        {
                            moveset.doMove2(2);
                            Debug.Log("straight");
                        }
                    }

                    if (randNum > 60 && randNum <= 100)
                    {
                        if (moveset.getMoveSetCost(4) > player.SP)
                        {
                            moveset.doMove2(1);
                            Debug.Log("No SP. Enemy Performs Jab");
                        }

                        else
                        {
                            moveset.doMove2(4);
                            Debug.Log("sunday");
                        }
                    }

                }

            }
            // this function implements AI to decide which move to take
            // returns number of move
            // call 
            // doMove(number); (enemy might have it's own version being worked on by JJ)



            // CHECK IF DEAD FIRST,
            // Ash addition, moved here;
            if (player.HP <= 0)
            {
                player.KO = true;
                turn.MatchEnd = true;
                turn.PlayerTurn = false;
                turn.EnemyTurn = false;
            }
        }
    }

   
}
