using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Most of this originally written by Ash
// Additions noted
// things renamed from :
// EnemyStateMachine -> MatchTurnEnemy
// BaseEnemy enemy -> EnemyObject enemy
// ADDTOLIST -> CHOOSEACTION
// DEAD -> KOd

public class MatchTurnEnemy : MonoBehaviour
{
    public EnemyObject enemy;


    // THIS IS WHAT DON HAD IN HIS SCRIPTS (and not the other stuff):
    // Maybe not needed...TBD
    // End of player turn switches this to true, then enemyTurn() proceeds
    // public bool isEnemyTurn = false;

    // JJ Addition:
    private MatchTurn MT;


    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        KOd // Ash version = 'DEAD'
    }


    public TurnState currentState;

    // Ash version only:
    //for the progress bar
    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;
    public Image HPProgressBar;
    public Image StaminaProgressBar;

    // JJ added
    //for animations
    private Vector3 startposition;

    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.PROCESSING;


        // JJ stuff:
        //who's in the battle 
        MT = GameObject.Find("BattleManager").GetComponent<MatchTurn>();
        //for animations
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Enemy state = " + currentState);

        switch (currentState)
        {
            case (TurnState.PROCESSING):
               
                // JJ addition
                UpdateFight();
                break;

            case (TurnState.CHOOSEACTION): // Ash = .ADDTOLIST

                // JJ:
                ChooseAction();
                currentState = TurnState.WAITING;
                break;

            case (TurnState.WAITING):
                break;

            case (TurnState.ACTION):

                break;

            case (TurnState.KOd):

                break;
        }
    }


    // JJ:
    void UpdateFight()
    {
        //This function could be a good place for updating hp bar, etc. 
        cur_cooldown = cur_cooldown + Time.deltaTime;
        float calc_cooldown = cur_cooldown / max_cooldown;
        HPProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), HPProgressBar.transform.localScale.y, HPProgressBar.transform.localScale.z);
        StaminaProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), StaminaProgressBar.transform.localScale.y, StaminaProgressBar.transform.localScale.z);
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.CHOOSEACTION; // renamed from .ADDTOLIST
        }
    }

    // JJ:
    //The enemy's attack choice (maybe where AI could be implemented) 
    void ChooseAction()
    {
        TurnHandler myAttack = new TurnHandler();
        myAttack.Attacker = enemy.name; //name of attacker
        myAttack.AttacksGameObject = this.gameObject; //who attacks
        myAttack.AttackersTarget = this.gameObject; // who it is attacking
        MT.CollectActions(myAttack);
    }

}
