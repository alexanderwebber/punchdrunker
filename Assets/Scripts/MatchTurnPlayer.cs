using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Unless denoted by a commented out link, TK wrote literally everything here

public class MatchTurnPlayer : MonoBehaviour
{
    public MatchTurn turn;
    public PlayerObject player;
    public EnemyObject enemy;
    public MoveSetScript moveset;
    public BattleTextScript btext;
    // add movesetscript shit here

    // Certain player buttons will be disabled if not player turn
    // or player does not have that ability

    public GameObject allButtonsObj;
    public GameObject counterButton;
    public GameObject sundayButton;
    public GameObject butterButton;

    public Button jabButton;


    public void doPlayerTurn()
    {
        Debug.Log("You are inside Player's turn!");

        // Do whatever setup needs to be done for player turn

        // CHECK IF DEAD FIRST,
        // Ash addition:
        if (player.HP <= 0)
        {
            player.KO = true;
            turn.MatchEnd = true;
            turn.PlayerTurn = false;
            turn.EnemyTurn = false;
        }
        else
        {


            // Start by enabling all regular buttons

            // if counter, enable counter button
            // if have 1st ability, enable sunday p
            // if have 2nd ability, enable butterbee

            // If player was defending last turn; turn it off
            player.Guard = false;


            // Decide which button to select:
            // if counter, counter
            // else jab

            //        counterButton.GetComponent<Button>().Select();

            // TK addition:
            if (enemy.HP <= 0)
            {
                enemy.KO = true;
                turn.MatchEnd = true;
                Debug.Log("match end = " + turn.MatchEnd);
                turn.PlayerTurn = false;
                turn.EnemyTurn = false;
            }

        }

    }

    public void playerSelect(int moveNum)
    {
        // Reset error text on make selection
        btext.updateErrorText(" ");

        // alter doMove() so also can recieve player and enemy objects 
        // and react based on whose turn it is

        if (moveset.getMoveSetCost(moveNum) > player.SP)
        {
            Debug.Log("you cannot afford this move w/current SP!");
            btext.updateErrorText("NOT ENOUGH SP!");
        }
        else
        {
            // Disable player Buttons!!!!!!!!!!!

            moveset.doMove(moveNum);

            // DOES THE SELECTED ACTION WOO

            // do yield playerturn
            // after done all the stuff; set Playerturn to falso
        }
    }

    public void yieldPlayerTurn()
    {
        turn.PlayerTurn = false;
        turn.EnemyTurn = true;
    }
}
