using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchTurnPlayer : MonoBehaviour
{

    private MatchTurn MT;
    public PlayerObject player;

    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        KOd
    }

    public TurnState currentState;

    public GameObject Selector;

    // Start is called before the first frame update
    void Start()
    {
        Selector.SetActive(false);
        MT = GameObject.Find("BattleManager").GetComponent<MatchTurn>();
        currentState = TurnState.PROCESSING;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentState);

        switch (currentState)
        {
            case (TurnState.PROCESSING):

                UpgradeProgressBar();
                break;

            case (TurnState.ADDTOLIST):

                MT.PlayerToManage.Add(this.gameObject);
                currentState = TurnState.WAITING;
                break;

            case (TurnState.WAITING):
                //idle state

                break;

            case (TurnState.SELECTING):

                break;

            case (TurnState.ACTION):

                break;

            case (TurnState.KOd):

                break;
        }

    }

    void UpgradeProgressBar()
    {

        currentState = TurnState.ADDTOLIST;
    }
}
