﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// JJ addition
[System.Serializable]

public class EnemyObject
{

    // Ash's work:
    public string name;
    public int baseHP;
    public int currentHP;
    //Extra stuff can go here, like stamina, power, etc.
    //Can put constant variables here, will do this later.
    public float jab;
    public float cross;
    public float block;


    // Everything below this line added by Don:

    public int EnemyMaxHP { get; private set; }
    public int EnemyMaxStamina { get; private set; }
    public int EnemyPower { get; private set; }
    public int EnemySpeed { get; private set; }
    public int EnemyTough { get; private set; }

    //https://unity3d.com/learn/tutorials/topics/scripting/delegates
    //created for switching moves depending on enemy type

    public delegate void EnemyMove1Del();
    public delegate void EnemyMove2Del();
    public delegate void EnemyMove3Del();
    public delegate void EnemyMove4Del();
    public EnemyMove1Del enemyMove1;
    public EnemyMove2Del enemyMove2;
    public EnemyMove3Del enemyMove3;
    public EnemyMove4Del enemyMove4;

    public void EnemySkipTurn()
    {
        MatchTurnEnemy mte = new MatchTurnEnemy();
        if (mte.isEnemyTurn == true)
        {
            mte.isEnemyTurn = false;
        }
    } 

    public bool inTraining = false; // Need to implement function to switch to true when in Training mode

    public EnemyObject()
    {
        EnemyMaxHP = 100;
        EnemyMaxStamina = 100;
        EnemyPower = 75;
        EnemySpeed = 55;
        EnemyTough = 50;
    }

    public EnemyObject(int hp, int st, int p, int t, int sp)
    {
        EnemyMaxHP = hp;
        EnemyMaxStamina = st;
        EnemyPower = p;
        EnemyTough = t;
        EnemySpeed = sp;
    }

    void Start()
    {
        SavePrefs prefs = new SavePrefs();
        EnemyObject current = new EnemyObject();

        if (inTraining == true)
        {
            //WIP
        } 
        else
        {
            if (prefs.PlayerRank == 3)
            {
                current = new PowerEnemy(100, 100, 100, 50, 75);
            }
            else if (prefs.PlayerRank == 2)
            {
                current = new DefenseEnemy(100, 100, 50, 75, 100);
            }
            else if (prefs.PlayerRank == 1)
            {
                current = new SpeedEnemy(100, 100, 75, 100, 50);
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