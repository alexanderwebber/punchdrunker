using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// JJ addition
[System.Serializable]

public class EnemyObject : MonoBehaviour
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
    public int TurnCount { get; set; }
    public bool HighHPStatus = true;
    public bool MiddleHPStatus = false;
    public bool LowHpStatus = false;
    public bool FirstTurnStatus = true;
    public bool SkipStatus = false;

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
    public EnemyBehaviorTree EnemyTree;

    public Result EnemyMove1inTree(EnemyBehaviorTree tree)
    {
        enemyMove1();
        return new Result(true);
    }

    public Result EnemyMove2inTree(EnemyBehaviorTree tree)
    {
        enemyMove2();
        return new Result(true);
    }

    public Result EnemyMove3inTree(EnemyBehaviorTree tree)
    {
        enemyMove3();
        return new Result(true);
    }

    public Result EnemyMove4inTree(EnemyBehaviorTree tree)
    {
        enemyMove4();
        return new Result(true);
    }

    public Result DummyNode(EnemyBehaviorTree tree)
    {
        return new Result(true);
    }

    public EnemyBehaviorTree BuildTree()
    {
        Dictionary<Node, float> HighHPMoveset = new Dictionary<Node, float>
        {
            { new Leaf(EnemyMove1inTree), 0.5F },
            { new Leaf(EnemyMove2inTree), 0.5F }
        };

        Dictionary<Node, float> MiddleHPMoveset = new Dictionary<Node, float>
        {
            { new Leaf(EnemyMove2inTree), 0.5F },
            { new Leaf(EnemyMove3inTree), 0.5F },
        };

        Dictionary<Node, float> LowHPMoveset = new Dictionary<Node, float>
        {
            { new Leaf(EnemyMove1inTree), 0.25F },
            { new Leaf(EnemyMove2inTree), 0.25F },
            { new Leaf(EnemyMove3inTree), 0.25F },
            { new Leaf(EnemyMove4inTree), 0.25F }
        };

        var LowHP = new SelectorRandomArray(LowHPMoveset);
        var MiddleHP = new SelectorRandomArray(MiddleHPMoveset);
        var HighHP = new SelectorRandomArray(HighHPMoveset);

        var FirstTurnAtLowHP = new Selector(IfFirstTurnInHpState, new Leaf(EnemyMove4inTree), LowHP);
        var FirstTurnAtMiddleHP = new Selector(IfFirstTurnInHpState, new Leaf(EnemyMove3inTree), MiddleHP);

        var CheckHPIsLow = new Selector(IfLowHp, FirstTurnAtLowHP, new Leaf(DummyNode));
        var CheckHPIsMedium = new Selector(IfMiddleHP, FirstTurnAtMiddleHP, CheckHPIsLow);
        var CheckHPIsHigh = new Selector(IfHighHP, HighHP, CheckHPIsMedium);

        EnemyBehaviorTree TempTree = new EnemyBehaviorTree(CheckHPIsHigh, 1);

        return TempTree;

    }
    
    /*
    public void EnemySkipTurn()
    {
        MatchTurnEnemy mte = new MatchTurnEnemy();
        if (mte.isEnemyTurn == true)
        {
            mte.isEnemyTurn = false;
        }
    } 
    */

    public void SkipsTurn(int turns)
    {
        if (SkipStatus == false)
            SkipStatus = true;
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

    public bool IsAboveThreeQuartersHP()
    {
        if (currentHP >= 0.75 * EnemyMaxHP)
            return true;
        else
            return false;
    }

    public bool IsBetweenOneQuarterAndThreeQuartersHP()
    {
        if (currentHP >= 0.25 * EnemyMaxHP && currentHP < 0.75 * EnemyMaxHP)
            return true;
        else
            return false;        
    }

    public bool IsBelowOneQuarterHP()
    {
        if (currentHP < 0.25 * EnemyMaxHP)
            return true;
        else
            return false;
    }

    public Result IfHighHP(EnemyBehaviorTree tree)
    {
        if (IsAboveThreeQuartersHP())
            HighHPStatus = true;
        else
            HighHPStatus = false;
        return new Result(true);
    }

   public Result IfMiddleHP(EnemyBehaviorTree tree)
    {
        if (IsBetweenOneQuarterAndThreeQuartersHP())
            MiddleHPStatus = true;
        else
            MiddleHPStatus = false;
        return new Result(true);
    }

    public Result IfLowHp(EnemyBehaviorTree tree)
    {
        if (IsBelowOneQuarterHP())
            LowHpStatus = true;
        else
            LowHpStatus = false;
        return new Result(true);
    }

    public Result IfFirstTurnInHpState(EnemyBehaviorTree tree)
    {
        if (IsFirstTurnInHPState())
            FirstTurnStatus = true;
        else
            FirstTurnStatus = false;
        return new Result(true);
    }

    public bool IsFirstTurnInHPState()
    {
        if (TurnCount == 0)
            return true;
        else
            return false;
    }

    public void ResetTurnCount()
    {
        TurnCount = 0;
    }

    public float ChanceGenerator()
    {
        return UnityEngine.Random.Range(0f, 1f);
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