using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// JJ addition
[System.Serializable]

public class PlayerObject : MonoBehaviour
{
    public int PlayerMaxHP { get; private set; }
    public int PlayerMaxStamina { get; private set; }
    public int PlayerPower { get; private set; }
    public int PlayerSpeed { get; private set; }
    public int PlayerTough { get; private set; }

    //https://unity3d.com/learn/tutorials/topics/scripting/delegates
    //created for switching moves depending on Player type

    public delegate void PlayerMove1Del();
    public delegate void PlayerMove2Del();
    public delegate void PlayerMove3Del();
    public delegate void PlayerMove4Del();
    public PlayerMove1Del PlayerMove1;
    public PlayerMove2Del PlayerMove2;
    public PlayerMove3Del PlayerMove3;
    public PlayerMove4Del PlayerMove4;

    public void PlayerSkipTurn()
    {
        MatchTurnPlayer mtp = new MatchTurnPlayer();
        if (mtp.isPlayerTurn == true)
        {
            mtp.isPlayerTurn = false;
        }
    }

    public bool inTraining = false; // Need to implement function to switch to true when in Training mode

    public PlayerObject()
    {
        PlayerMaxHP = 100;
        PlayerMaxStamina = 100;
        PlayerPower = 75;
        PlayerSpeed = 55;
        PlayerTough = 50;
    }

    public PlayerObject(int hp, int st, int p, int t, int sp)
    {
        PlayerMaxHP = hp;
        PlayerMaxStamina = st;
        PlayerPower = p;
        PlayerTough = t;
        PlayerSpeed = sp;
    }

    void Start()
    {
        SavePrefs prefs = new SavePrefs();
        PlayerObject current = new PlayerObject();

        if (inTraining == true)
        {
            //WIP
        }
        else
        {
            if (prefs.PlayerRank == 3)
            {
                current = new PowerPlayer(100, 100, 100, 50, 75);
            }
            else if (prefs.PlayerRank == 2)
            {
                current = new DefensePlayer(100, 100, 50, 75, 100);
            }
            else if (prefs.PlayerRank == 1)
            {
                current = new SpeedPlayer(100, 100, 75, 100, 50);
            }
            else
            {

            }
        }
    }

    void Update()
    {

    }

}

// Player (Power Type) 
public class PowerPlayer : PlayerObject
{
    public PowerPlayer(int hp, int st, int p, int t, int sp) : base(hp, st, p, t, sp)
    {
        PlayerMove1 = StraightShot;
        PlayerMove2 = AbsoluteUnit;
        PlayerMove3 = MegaRightHook;
        PlayerMove4 = HatefulPunch;

    }

    void StraightShot()
    {

    }

    void AbsoluteUnit()
    {

    }

    void MegaRightHook()
    {

    }

    void HatefulPunch()
    {

    }
}


// Player (Defense Type)
public class DefensePlayer : PlayerObject
{
    public DefensePlayer(int hp, int st, int p, int t, int sp) : base(hp, st, p, t, sp)
    {
        PlayerMove1 = ScratchSurface;
        PlayerMove2 = Synthesize;
        PlayerMove3 = RightHook;
        PlayerMove4 = Cornered;
    }

    void ScratchSurface()
    {
        //WIP
    }

    void Synthesize()
    {
        //WIP
    }

    void RightHook()
    {
        //WIP
    }

    void Cornered()
    {
        //WIP
    }
}


// Player (Speed Type)
public class SpeedPlayer : PlayerObject
{
    public SpeedPlayer(int hp, int st, int p, int t, int sp) : base(hp, st, p, t, sp)
    {
        PlayerMove1 = Unavoidable;
        PlayerMove2 = Tireless;
        PlayerMove3 = ShutterSpeed;
        PlayerMove4 = Evasion;
    }

    void Unavoidable()
    {
        //WIP
    }

    void Tireless()
    {
        //WIP
    }

    void ShutterSpeed()
    {
        //WIP
    }

    void Evasion()
    {
        //WIP
    }

}