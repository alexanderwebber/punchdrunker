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
    // End of player turn switches this to true, then enemyTurn() proceeds
    public bool isEnemyTurn = false;

    // JJ Addition:
    private MatchTurn MT;


    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION, // Ash verison = 'ADDTOLIST'
        WAITING,
        // Ash version had:
        // SELECTING,
        ACTION,
        KOd // Ash version = 'DEAD'
    }


    public TurnState currentState;

    // Ash version only:
    //for the progress bar
    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;
    public Image ProgressBar;

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
        Debug.Log("Enemey state = " + currentState);

        switch (currentState)
        {
            case (TurnState.PROCESSING):
                // Ash version only:
                 UpgradeProgressBar();

                // JJ addition
//                UpdateFight();
                break;

            case (TurnState.CHOOSEACTION): // Ash = .ADDTOLIST

                // JJ:
                ChooseAction();
                currentState = TurnState.WAITING;

                break;

            case (TurnState.WAITING):
                break;

            // Ash:
/*            case (TurnState.SELECTING):

                break;
*/
            case (TurnState.ACTION):

                break;

            case (TurnState.KOd):

                break;
        }
    }


    // ASH only version:
    void UpgradeProgressBar()
    {
        cur_cooldown = cur_cooldown + Time.deltaTime;
        float calc_cooldown = cur_cooldown / max_cooldown;
        // Need progress bar image to uncomment:
        // ProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.CHOOSEACTION; // renamed from .ADDTOLIST
        }

    }

    // JJ:
    void UpdateFight()
    {
        //This function could be a good place for updating hp bar, etc. 
        currentState = TurnState.CHOOSEACTION;
    }

    // JJ:
    //The enemy's attack choice (maybe where AI could be implemented) 
    void ChooseAction()
    {
        TurnHandler myAttack = new TurnHandler();
        myAttack.Attacker = enemy.name;
        myAttack.AttacksGameObject = this.gameObject;
        // myAttack.AttackersTarget = MT.PlayerTurnList[Random.Range(0, MT.PlayerTurnList.Count)]; //doesn't make sense for our game.. needs revision
        MT.CollectActions(myAttack);
    }

}
