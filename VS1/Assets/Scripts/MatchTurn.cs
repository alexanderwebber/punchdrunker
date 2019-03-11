using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this controls every game turn (including player and enemy turns which have
 * their own scripts
 */
 
    // For the most part Ash wrote this additions noted...


public class MatchTurn : MonoBehaviour // Ash verison called BattleStateMachine
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION
    }
    public PerformAction turnStates; // Ash version battleStates

    // Ash version: TurnList was 'PerformList', TurnHandler was 'HandleTurn'
    public List<TurnHandler> TurnList = new List<TurnHandler>();

    // JJ Additions:
    public List<GameObject> PlayerTurnList = new List<GameObject>();
    public List<GameObject> EnemyTurnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        turnStates = PerformAction.WAIT; // ash version = 'battleStates'
        // JJ Addition:
        EnemyTurnList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

        //Ash Addition:
        PlayerTurnList.AddRange(GameObject.FindGameObjectsWithTag("Player"));

    }

    // Update is called once per frame
    void Update()
    {
        switch (turnStates) // Ash= 'battleStates'
        {
            case (PerformAction.WAIT):

                break;

            case (PerformAction.TAKEACTION):

                break;

            case (PerformAction.PERFORMACTION):

                break;

        }
    }

    // JJ Addition:
    public void CollectActions(TurnHandler input)
    {
        TurnList.Add(input);
    }
}
