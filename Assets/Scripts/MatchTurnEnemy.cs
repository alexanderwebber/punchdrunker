using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatchTurnEnemy : MonoBehaviour
{
    private MatchTurn MT;
    public EnemyObject enemy;

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        KOd
    }

    public TurnState currentState;

    public GameObject PlayerToAttack;

    //for animations
    private Vector3 startposition;

    private bool actionStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.PROCESSING;

        //who's in the battle 
        MT = GameObject.Find("BattleManager").GetComponent<MatchTurn>();

        //for animations
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentState);

        switch (currentState)
        {
            case (TurnState.PROCESSING):

                UpdateFight();
                break;

            case (TurnState.CHOOSEACTION):

                ChooseAction();
                currentState = TurnState.WAITING;

                break;

            case (TurnState.WAITING):
                Debug.Log("inside turnstate waiting");
                break;


            case (TurnState.ACTION):
                StartCoroutine(TimeForAction());
                break;

            case (TurnState.KOd):

                break;
        }
    }

    void UpdateFight()
    {
        //This function could be a good place for updating hp bar, etc. 
        currentState = TurnState.CHOOSEACTION;
    }

    //The enemy's attack choice (maybe where AI could be implemented) 
    void ChooseAction()
    {
        TurnHandler myAttack = new TurnHandler();
        myAttack.Attacker = enemy.name;
        myAttack.Type = "Enemy";
        myAttack.AttacksGameObject = this.gameObject;
       // myAttack.AttackersTarget = MT.PlayerTurnList[Random.Range(0, MT.PlayerTurnList.Count)]; //doesn't make sense for our game.. needs revision
        MT.CollectActions(myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if(actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        //animate enemy
        //wait a moment
        yield return new WaitForSeconds(0.5f);
        //perform damage
        //animate enemy back to start position

        //remove this performer from the list in matchturn
        MT.TurnList.RemoveAt(0);

        //reset MT -> wait
        MT.turnStates = MatchTurn.PerformAction.WAIT;

        actionStarted = false;

        //reset this enemy state

        currentState = TurnState.PROCESSING;
    }

}
