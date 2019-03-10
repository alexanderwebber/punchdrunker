using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

/*
 * this controls every game turn (including player and enemy turns which have
 * their own scripts
 */

public class MatchTurn : MonoBehaviour
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION
    }

    public PerformAction turnStates;

    public List<TurnHandler> TurnList = new List<TurnHandler>();
    public List<GameObject> PlayerTurnList = new List<GameObject>();
    public List<GameObject> EnemyTurnList = new List<GameObject>();

    public enum PlayerGUI
    {
        ACTIVATE,
        WAITING,
        INPUT,
        DONE
    }

    public PlayerGUI PlayerInput;

    public List<GameObject> PlayerToManage = new List<GameObject>();
    private TurnHandler PlayerChoice;

    public GameObject AttackPanel;

    // Start is called before the first frame update
    void Start()
    {
        turnStates = PerformAction.WAIT;
        EnemyTurnList.AddRange(GameObject.FindGameObjectsWithTag("EnemyObject"));
        EnemyTurnList.AddRange(GameObject.FindGameObjectsWithTag("PlayerObject"));
        PlayerInput = PlayerGUI.ACTIVATE;

        AttackPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (turnStates)
        {
            case (PerformAction.WAIT):
                if(TurnList.Count > 0)
                {
                    turnStates = PerformAction.TAKEACTION;
                }
                break;

            case (PerformAction.TAKEACTION):
                GameObject performer = GameObject.Find(TurnList[0].Attacker);

                if (TurnList[0].Type == "Enemy")
                {
                    MatchTurnEnemy MTE = performer.GetComponent<MatchTurnEnemy> ();
                    MTE.PlayerToAttack = TurnList[0].AttackersTarget;
                    MTE.currentState = MatchTurnEnemy.TurnState.ACTION;
                }

                if (TurnList[0].Type == "Player")
                {
                    Debug.Log("Player's Turn");
                }
                turnStates = PerformAction.PERFORMACTION;
                break;

            case (PerformAction.PERFORMACTION):

                break;

        }

        switch (PlayerInput)
        {
            case (PlayerGUI.ACTIVATE):
                if(PlayerToManage.Count > 0)
                {
                    PlayerToManage[0].transform.Find("Selector").gameObject.SetActive(true);
                    PlayerChoice = new TurnHandler();
                    AttackPanel.SetActive(true);
                    PlayerInput = PlayerGUI.WAITING;
                }

                break;


            case (PlayerGUI.WAITING):

                //idle state

                break;

            case (PlayerGUI.DONE):
                PlayerInputComplete();
                break;

        }
        }

    public void CollectActions(TurnHandler input)
    {
        TurnList.Add(input);
    }

    public void Input()
    {
        PlayerChoice.Attacker = PlayerToManage[0].name;
        PlayerChoice.AttacksGameObject = PlayerToManage[0];
      
        PlayerChoice.Type = "Player";


        AttackPanel.SetActive(false);
        PlayerInput = PlayerGUI.DONE;
    }

    void PlayerInputComplete()
    {
        TurnList.Add(PlayerChoice);
        PlayerToManage[0].transform.Find("Selector").gameObject.SetActive(false);
        PlayerToManage.RemoveAt(0);
        PlayerInput = PlayerGUI.ACTIVATE;
    }
}
