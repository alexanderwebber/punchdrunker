using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Unless denoted by a commented out link, TK wrote literally everything here

public class EnemyObject : MonoBehaviour
{
    public SavePrefs prefs;
    public PlayerObject player;
    public MoveSetScript moveSet;

    public Image HPbar;

    [HideInInspector]
    public int PlayerRank, MaxHP, HP, MaxSP, SP, PWR, SPD, TGH;

    // DEF = % of enemy attack damage can be mitigated by player
    // DMG = % of attacks base damage can be used by player
    // EVA = % chance of evading enemy attack
    // LCK = % chance of a critical attack (DMG*1.5)
    // REC = % of HP/SP recovered when using Recovery Move
    // CounterChance = % chance of generating a counter
    [HideInInspector]
    public float HPpercent, DMG, DEF, EVA, LCK, REC, CounterChance;

    // Special abilities player can learn by ranking up & spending EXP
    public bool SundayPunch;
    public bool ButterBee;
    public bool DynamiteBlow;

    public bool Guard;
    public bool KO;

    // I might have to change/move these idk...
    public bool Evasion;
    public bool Miss;
    public bool Dazed;

    // Stores player's previous moves including things like missing the enemy;
    public int prevMove;

    // Start is called before the first frame update
    void Start()
    {
        // Call function to populate Player Object with correct values
        populateEnemyObject();
        displayEnemyStats();
    }

    public void populateEnemyObject()
    {
        prevMove = -1; // Previous move doesn't exist because just started
        if (prefs.GetPrefBool("Sparring"))
        {
            // If training, populate with player's stats -1 each
            populateSparringEnemyObject();
        }
        else
        {
            PlayerRank = prefs.GetPref("PlayerRank");
            if (PlayerRank >= 3)
            {
                populateRank2EnemyObject();
            }
            if (PlayerRank == 2)
            {
                populateRank2EnemyObject();
                // CHANGE THIS BACK TO RANK 1 ENEMY LATER
                // populateRank1EnemyObject();
            }
            else
            {
                populateRank2EnemyObject();
                // CHANGE THIS BACK T C ENEMY LATER
                // populateRankCEnemyObject();
            }
        }
    }

    void populateRank2EnemyObject()
    {
        PWR = 10;
        SPD = 4;
        TGH = 7;

        populateDerivedValues();

        SundayPunch = true;
        ButterBee = false;
        DynamiteBlow = false;
    }

    void populateRank1EnemyObject()
    {
        PWR = 6;
        SPD = 10;
        TGH = 6;

        populateDerivedValues();

        SundayPunch = false;
        ButterBee = true;
        DynamiteBlow = false;
    }

    void populateRankCEnemyObject()
    {
        PWR = 10;
        SPD = 3;
        TGH = 12;

        populateDerivedValues();

        SundayPunch = false;
        ButterBee = false;
        DynamiteBlow = true;
    }

    public void populateSparringEnemyObject()
    {
        PWR = prefs.GetPref("PlayerPower");
        SPD = prefs.GetPref("PlayerSpeed");
        TGH = prefs.GetPref("PlayerTough");
        PWR--;
        SPD--;
        TGH--;
        // testing if too weak or not:
        PWR--;
        SPD--;
        TGH--;

        populateDerivedValues();

        SundayPunch = true;     // CHANGE THIS TO FALSE LATER
        ButterBee = false;
        DynamiteBlow = false;
    }

    public void populateDerivedValues()
    {
        MaxSP = (int)(PWR * 20);
        SP = MaxSP;
        MaxHP = (int)((TGH * 100) / 2);
        HP = MaxHP;

        DMG = ((float)PWR * 10) / 100;
        DEF = ((float)TGH * 10) / 200;
        EVA = ((float)SPD * 10) / 300;
        LCK = ((float)PWR + TGH + (2 * SPD)) / 200;
        REC = (float)SPD / 200;
    }


    void displayEnemyStats()
    {
        Debug.Log("Enemy Values:");
        consoleStats();
    }

    public void consoleStats()
    {
        Debug.Log("HP: " + MaxHP);
        Debug.Log("SP: " + MaxSP);
        Debug.Log("PWR: " + PWR);
        Debug.Log("SPD: " + SPD);
        Debug.Log("TGH: " + TGH);
        Debug.Log("DMG %: " + DMG);
        Debug.Log("DEF %: " + DMG);
        Debug.Log("EVA %: " + EVA);
        Debug.Log("LCK %: " + LCK);
        Debug.Log("REC %: " + REC);
        Debug.Log("Counter Chance %: " + CounterChance);

        Debug.Log("Sunday: " + SundayPunch);
        Debug.Log("ButterBee: " + ButterBee);
        Debug.Log("Dynamite: " + DynamiteBlow);
    }

    public void updateEnemyBar()
    {
        HPpercent = (float)HP / MaxHP;

        HPbar.fillAmount = HPpercent;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
