using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// TK wrote all of this; additions noted
public class SavePrefs : MonoBehaviour
{


    // { get; private set; } added by Don

    // Player rank (can be 3,2,1,0; 0 = Champion & win game)
    public int PlayerRank { get; private set; }

    // Current stats for player
    public int PlayerMaxHP { get; private set; }
    public int PlayerMaxStamina { get; private set; }
    public int PlayerPower { get; private set; }
    public int PlayerSpeed { get; private set; }
    public int PlayerTough { get; private set; }

    // Player's current EXP amount 
    // (more like currency to be spent)
    public int PlayerEXP { get; private set; }

    // Used to cap EXP gain btw levels ?
    public int PlayerTotalGainedEXP { get; private set; }

    // Toggles on abilities
    // bool not allowed; 0 is falso / 1 is true
    // Winning 1st match and ranking up to 2 toggles Ability1 to true/1;
    int NewAbility1;
    int NewAbility2;
    bool BoolAbility1;
    bool BoolAbility2;

    // -----------------------------------------------------------------------//

    // This function is called when player selects 'Play' from
    // the MAIN MENU. It resets all Prefs to the starting positions we want
    // because it is a new game.
    public void NewGamePrefSet()
    {
        // SET PLAYER STARTING STAT VALUES HERE!!!!!
        // THESE ARE RANDOMLY CHOSEN VALUES FOR TESTING
        // CHANGE THEM!!!!!!!
        // *change this note after you fix them also :o
        PlayerMaxHP = 100;
        PlayerMaxStamina = 100;
        PlayerPower = 75;
        PlayerSpeed = 55;
        PlayerTough = 50;

        // Starting rank for player is always 3
        PlayerPrefs.SetInt("PlayerRank", 3);

        // IDK what the values of these should be yet
        // We will have to figure that out later
        PlayerPrefs.SetInt("PlayerMaxHP", PlayerMaxHP);
        PlayerPrefs.SetInt("PlayerMaxStamina", PlayerMaxStamina);
        PlayerPrefs.SetInt("PlayerPower", PlayerPower);
        PlayerPrefs.SetInt("PlayerSpeed", PlayerSpeed);
        PlayerPrefs.SetInt("PlayerTough", PlayerTough);

        // Player starts game with 0 EXP
        PlayerPrefs.SetInt("PlayerEXP", 0);
        PlayerPrefs.SetInt("PlayerTotalGainedEXP", 0);

        // Bool don't exist for prefs :< so we have to use 0/1
        // 0 is falso / 1 is true
        PlayerPrefs.SetInt("NewAbility1", 0);
        PlayerPrefs.SetInt("NewAbility1", 0);

        // DO NOT FORGET TO SAVE AFTER UPDATE!
        PlayerPrefs.Save();

        Debug.Log("A new game has been started with the default player values.");
    }

    // -----------------------------------------------------------------------//

    // Simple function using arguments to update a single playerpref value
    // must include the CORRECT playerprefs name or no work-o
    public void SavePref(string prefname, int val)
    {
        Debug.Log("Saving [" + prefname + "] with new value of [" + val + "].");
        PlayerPrefs.SetInt(prefname, val);
        PlayerPrefs.Save();

        // the following is for testing
        int temp = PlayerPrefs.GetInt(prefname);
        Debug.Log("Player Pref [" + prefname + "] saved with new value of [" + temp + "].");
    }

    // -----------------------------------------------------------------------//

    // Return value of a specified player pref
    public int GetPref(string prefname)
    {
        int temp = PlayerPrefs.GetInt(prefname);
        Debug.Log("Player Pref [" + prefname + "] is value [" + temp + "].");
        return temp;
    }

    // -----------------------------------------------------------------------//

    // Pulls all Saved PlayerPrefs values and outputs them to the console
    // This function is for testing
    public void ConsoleAllPlayerPrefValues()
    {
        PlayerRank = PlayerPrefs.GetInt("PlayerRank");
        PlayerMaxHP = PlayerPrefs.GetInt("PlayerMaxHP");
        PlayerMaxStamina = PlayerPrefs.GetInt("PlayerMaxStamina");
        PlayerPower = PlayerPrefs.GetInt("PlayerPower");
        PlayerSpeed = PlayerPrefs.GetInt("PlayerSpeed");
        PlayerTough = PlayerPrefs.GetInt("PlayerTough");
        PlayerEXP = PlayerPrefs.GetInt("PlayerEXP");
        PlayerTotalGainedEXP = PlayerPrefs.GetInt("PlayerTotalGainedEXP");

        // bool not allowed; 0 is falso / 1 is true
        NewAbility1 = PlayerPrefs.GetInt("NewAbility1");
        if (NewAbility1 != 1)
            BoolAbility1 = false;
        else
            BoolAbility1 = true;

        NewAbility2 = PlayerPrefs.GetInt("NewAbility2");
        if (NewAbility2 != 1)
            BoolAbility2 = false;
        else
            BoolAbility2 = true;

        Debug.Log("Player Rank = " + PlayerRank);
        Debug.Log("Player Max HP = " + PlayerMaxHP);
        Debug.Log("Player Max Stamina = " + PlayerMaxStamina);
        Debug.Log("Player Power = " + PlayerPower);
        Debug.Log("Player Speed = " + PlayerSpeed);
        Debug.Log("Player Toughness = " + PlayerTough);
        Debug.Log("Player EXP = " + PlayerEXP);
        Debug.Log("Total Gained EXP = " + PlayerTotalGainedEXP);
        Debug.Log("Gained Special Ability 1 = " + BoolAbility1);
        Debug.Log("Gained Special Ability 2 = " + BoolAbility2);
    }
        
    // -----------------------------------------------------------------------//

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }













    // -----------------------------------------------------------------------//

    /*
     * THESE FUNCTIONS WERE FOR TESTING PURPOSES :d
     */

    // this was for testing; ignore
    int score;

    public void GetScore()
    {
        PlayerPrefs.SetInt("Score", 20);
        PlayerPrefs.Save();

        score = PlayerPrefs.GetInt("Score");
        Debug.Log("This is the saved score: " + score);

        PlayerPrefs.SetInt("Score", 254);
        PlayerPrefs.Save();

        score = PlayerPrefs.GetInt("Score");
        Debug.Log("This is the saved score: " + score);

    }

    public void BasicScore()
    {
        score = PlayerPrefs.GetInt("Score");
        Debug.Log("This is the saved score: " + score);
    }

}