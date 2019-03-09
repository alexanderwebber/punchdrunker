using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Most of this originally written by Ash
// changes / additions noted
// things renamed from :
// HeroStateMachine -> MatchTurnPlayer
// BaseHero hero -> PlayerObject player;
// DEAD -> KOd

public class MatchTurnPlayer : MonoBehaviour
{
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


    // This is from Ash's version only:
    //for the progress bar
    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;
    public Image ProgressBar;


    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.PROCESSING;
        Debug.Log("START MatchTurnPlayer");

    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(currentState);

        switch (currentState)
        {
            case (TurnState.PROCESSING):
                // Ash version only:
                // UpgradeProgressBar();

                break;

            case (TurnState.ADDTOLIST):

                break;

            case (TurnState.WAITING):

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
        // All from Ash version Only:
        
        cur_cooldown = cur_cooldown + Time.deltaTime;
        float calc_cooldown = cur_cooldown / max_cooldown;
        ProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.ADDTOLIST;
        }


    }
}
