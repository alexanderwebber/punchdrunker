using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Most of this originally written by Ash
// changes / additions noted
// things renamed from :
// HeroStateMachine -> MatchTurnPlayer
// BaseHero hero -> PlayerObject player;
// DEAD -> KOd

public class MatchTurnPlayer : MonoBehaviour
{
    public PlayerObject player;

    public bool isPlayerTurn = false;

    private MatchTurn MT;

    [NonSerialized]
    public float HPpercent;

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        KOd
    }

    public TurnState currentState;


    // This is from Ash's version only:
    //for the progress bar
    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;
    public Image HPProgressBar;
    public Image StaminaProgressBar;


    private Vector3 startposition;
    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.PROCESSING;
        MT = GameObject.Find("BattleManager").GetComponent<MatchTurn>();
        startposition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player state = " + currentState);

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

        // TK: bar shows actual HP amount, rather than being a 2nd timer
        HPpercent = (float)player.currentHP / player.baseHP;
        HPProgressBar.fillAmount = HPpercent;
        // HPProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), HPProgressBar.transform.localScale.y, HPProgressBar.transform.localScale.z);

        StaminaProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), StaminaProgressBar.transform.localScale.y, StaminaProgressBar.transform.localScale.z);
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.CHOOSEACTION; // renamed from .ADDTOLIST
        }
    }

    // JJ:
    //The player's attack choice
    void ChooseAction()
    {
        TurnHandler myAttack = new TurnHandler();
        myAttack.Attacker = player.name;
        myAttack.AttacksGameObject = this.gameObject;
        myAttack.AttackersTarget = this.gameObject; // who it is attacking
        MT.CollectActions(myAttack);
    }

}

