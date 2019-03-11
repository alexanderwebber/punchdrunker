using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this controls every game turn (including player and enemy turns which have
 * their own scripts
 */

// Unless denoted by a commented out link, TK wrote literally everything here



public class MatchTurn : MonoBehaviour
{
    public MatchTurnPlayer pTurnScript;
    public MatchTurnEnemy eTurnScript;
    public SceneChanger scene; // Ash add

    public bool PlayerTurn;
    public bool EnemyTurn;
    public bool DoingTurn;
    public bool MatchEnd;


    // Start is called before the first frame update
    void Start()
    {
        PlayerTurn = false;
        EnemyTurn = false;
        DoingTurn = false;
        MatchEnd = false;
    }

    /*
     * Must be called after setup done
     * PlayerTurn
     * Check if Match Over
     * EnemyTurn
     * Check if Match Over
     */

    public void doMatchTurn()
    {
        if(!MatchEnd && !EnemyTurn)
        {
            if (!PlayerTurn)
            {
                PlayerTurn = true;
                // Call Player Turn
                pTurnScript.doPlayerTurn();

                // inside Player Turn stuff, PlayerTurn will be set to false
            }
        }
        if (!MatchEnd && !PlayerTurn)
        {
            EnemyTurn = true;

            // Call Enemy Turn
            eTurnScript.doEnemyTurn();

            // Since Don't have to wait for player input 
            // can just yield Enemy turn after return from function
            EnemyTurn = false;
        }
        if (MatchEnd)
        {
            // Do the things that happen at end of match
            // find out if player KO (game over) or player win(rankupscreen)
            //call to load the next scene
            if (pTurnScript.player.HP <= 0)
            {
                scene.masterSceneFadeOut(1);
            }
            else
            {
                scene.masterSceneFadeOut(7);
            }
            // Do the things that happen at end of match
            // find out if player KO (game over) or player win(rankupscreen)

        }
        DoingTurn = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (MatchEnd)
        {
            doMatchTurn();

        }
        if (DoingTurn)
        {
            doMatchTurn();
        }
        else if (!DoingTurn && !MatchEnd)
        {
            DoingTurn = true;
            doMatchTurn();
        } 
    }
}
