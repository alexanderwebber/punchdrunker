using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Unless denoted by a commented out link, TK wrote literally everything here

public class SpendEXPScript : MonoBehaviour
{
    public SavePrefs prefs;
    public GameObject testingUpdate;
    public GameObject abil1;
    public GameObject abil2;
    public GameObject noabil;
    public GameObject newabil;
    public GameObject upgrade;
    public GameObject noupgrade;

    public GameObject stopMenu;

    public Button exitButton;
    public Button powerButton;

    public GameObject popup;
    public GameObject popup2;

    int PlayerRank;
    int PlayerMaxHP;
    int PlayerMaxStamina;
    int PlayerPower;
    int PlayerSpeed;
    int PlayerTough;
    int PlayerEXP;
    int TotalEXP;
    bool Ability1;
    bool Ability2;
    int Rank2Upgrades;
    int Rank1Upgrades;
    int StatCost;
    bool Sparring;

    //    public Button abilityOne;
    //    public Button abilityTwo;

    // -----------------------------------------------------------------------//

    // Start is called before the first frame update
    void Start()
    {
        cheapoUpdate();
    }

    // -----------------------------------------------------------------------//

    public void cheapoUpdate()
    {
        displayTestText();
        displayCorrectButtons();

        if (newabil.activeInHierarchy)
        {
            newabil.GetComponent<Button>().Select();
        }
        else if (upgrade.activeInHierarchy)
        {
            upgrade.GetComponent<Button>().Select();
        }
        else
        {
            exitButton.Select();
        }

    }

    // -----------------------------------------------------------------------//

    void displayCorrectButtons()
    {
        stopMenu.SetActive(true);
        popup.SetActive(false);
        popup2.SetActive(false);
        displayAbilityButtons();
        displayRankButtons();
    }

    // -----------------------------------------------------------------------//

    public int getStatCost()
    {
        int NumHave;
        int Cost = 0;
        if (PlayerRank > 1)
        {
            NumHave = Rank2Upgrades;
            if (NumHave == 0)
            {
                Cost = 1500;
            }
            else if (NumHave == 1)
            {
                Cost = 3000;
            }
        }
        else
        {
            NumHave = Rank1Upgrades;
            if (NumHave == 0)
            {
                Cost = 3000;
            }
            else if (NumHave == 1)
            {
                Cost = 6000;
            }
        }
        return Cost;
    }

    // -----------------------------------------------------------------------//

    void displayRankButtons()
    {
        if (PlayerRank > 1 && Rank2Upgrades < 2) // rank 2+ and not maxed on rank2 upgrades
        {
            Debug.Log("IN DISPLAY RANK BUTTONS");
            upgrade.SetActive(true);
            noupgrade.SetActive(false);
        }
        else if (PlayerRank <= 1 && Rank1Upgrades < 2) // rank 1 and not maxed on rank2 upgrades
        {
            upgrade.SetActive(true);
            noupgrade.SetActive(false);
        }
        else // maxed on upgrades
        {
            upgrade.SetActive(false);
            noupgrade.SetActive(true);
        }
    }

    // -----------------------------------------------------------------------//

    void displayAbilityButtons()
    {
        if (!prefs.GetPrefBool("NewAbility1")) // don't have ability 1
        {
            newabil.SetActive(true);
            noabil.SetActive(false);

            abil1.SetActive(true);
            abil2.SetActive(false);
        }
        else // have ability 1
        {
            if (PlayerRank >= 2)
            {
                newabil.SetActive(false);
                noabil.SetActive(true);

                abil1.SetActive(false);
                abil2.SetActive(false);
            }
            else // PlayerRank = 1 & has a1
            {
                if (!prefs.GetPrefBool("NewAbility2")) // don't have a2
                {
                    newabil.SetActive(true);
                    noabil.SetActive(false);

                    abil1.SetActive(false);
                    abil2.SetActive(true);
                }
                else
                {
                    newabil.SetActive(false);
                    noabil.SetActive(true);

                    abil1.SetActive(false);
                    abil2.SetActive(false);
                }
            }
        }

    }

    // -----------------------------------------------------------------------//

    public void cancelPopup()
    {
        cheapoUpdate();
    }

    public void abilityPopup()
    {
        popup2.SetActive(true);
        stopMenu.SetActive(false);

        if (abil1.activeInHierarchy)
        {
            abil1.GetComponent<Button>().Select();
        }
        else
        {
            abil2.GetComponent<Button>().Select();
        }
    }

    public void upgradePopup()
    {
        popup.SetActive(true);
        stopMenu.SetActive(false);

        powerButton.Select();

        if (PlayerRank > 1)
        {
            Debug.Log("you can buy rank 2 stats");
        }
        else
        {
            Debug.Log("you can buy rank 1 stats");
        }
    }

    // -----------------------------------------------------------------------//

    public void buyAbility(int abilityNum)
    {
        int AbilityCost;
        if (PlayerRank > 1)
        {
            AbilityCost = 500;
        }
        else
        {
            AbilityCost = 1000;
        }

        if (AbilityCost > PlayerEXP)
        {
            Debug.Log("YOU CANNOT AFFORD THE ABILITY!");
        }
        else
        {
            Debug.Log("buy ability calling wtih cost of " + AbilityCost);
            prefs.buyAbilityYo(abilityNum, AbilityCost);
            cheapoUpdate();
        }
    }



    public void UpgradeStat(string statName) // PWR, SPD, TGH
    {
        int Cost = getStatCost();
        if (Cost > PlayerEXP)
        {
            Debug.Log("YOU CANNOT AFFORD THAT STAT UPGRADE");
        }
        else
        {
/*
            int NumHave;
            if (PlayerRank > 1)
            {
                NumHave = Rank2Upgrades;
            }
            else
            {
                NumHave = Rank1Upgrades;
            }
*/
            prefs.buyStatUpgrade(statName, Cost);
            cancelPopup();
        }
        //        cheapoUpdate();
    }

    // -----------------------------------------------------------------------//

    void displayTestText()
    {
        PlayerRank = PlayerPrefs.GetInt("PlayerRank");
        Ability1 = prefs.getAbilityTF("NewAbility1");
        Ability2 = prefs.getAbilityTF("NewAbility2");
        Sparring = prefs.getAbilityTF("SparringMatch");
        Rank2Upgrades = PlayerPrefs.GetInt("Rank2Upgrades");
        Rank1Upgrades = PlayerPrefs.GetInt("Rank1Upgrades");
        PlayerMaxHP = PlayerPrefs.GetInt("PlayerMaxHP");
        PlayerMaxStamina = PlayerPrefs.GetInt("PlayerMaxStamina");
        PlayerPower = PlayerPrefs.GetInt("PlayerPower");
        PlayerSpeed = PlayerPrefs.GetInt("PlayerSpeed");
        PlayerTough = PlayerPrefs.GetInt("PlayerTough");
        PlayerEXP = PlayerPrefs.GetInt("PlayerEXP");
        TotalEXP = PlayerPrefs.GetInt("TotalEXP");

        testingUpdate.GetComponent<Text>().text = "";
        testingUpdate.GetComponent<Text>().text += PlayerRank + "\n";
        testingUpdate.GetComponent<Text>().text += Sparring + "\n";
        testingUpdate.GetComponent<Text>().text += Ability1 + "\n";
        testingUpdate.GetComponent<Text>().text += Ability2 + "\n";
        testingUpdate.GetComponent<Text>().text += Rank2Upgrades + "\n";
        testingUpdate.GetComponent<Text>().text += Rank1Upgrades + "\n";
        testingUpdate.GetComponent<Text>().text += PlayerMaxHP + "\n";
        testingUpdate.GetComponent<Text>().text += PlayerMaxStamina + "\n";
        testingUpdate.GetComponent<Text>().text += PlayerPower + "\n";
        testingUpdate.GetComponent<Text>().text += PlayerSpeed + "\n";
        testingUpdate.GetComponent<Text>().text += PlayerTough + "\n";
        testingUpdate.GetComponent<Text>().text += PlayerEXP + "\n";
        testingUpdate.GetComponent<Text>().text += TotalEXP + "\n";
    }
    // -----------------------------------------------------------------------//

      // THESE ARE TESTING FUNCTIONS !!!!!!!!!

    public void toggleSparring()
    {
        // if Sparring = true, set false
        if (Sparring)
        {
            prefs.SavePrefBool("SparringMatch", false);
        }
        else // if false, set true
        {
            prefs.SavePrefBool("SparringMatch", true);
        }
        cheapoUpdate();
    }

    public void testRankUp()
    {
        if (PlayerRank > 0)
        {
//            PlayerPrefs.SetInt("PlayerRank", PlayerRank - 1);
            prefs.SavePref("PlayerRank", (PlayerRank - 1));
            PlayerRank = PlayerPrefs.GetInt("PlayerRank");
            cheapoUpdate();
        }
    }

    public void testEXPgain()
    {
        //        PlayerPrefs.SetInt("PlayerEXP", PlayerEXP+1000);
        prefs.GainEXP(1000);
        cheapoUpdate();
    }




    /*
     * FOR TESTING:


        // THIS IS FOR TESTING:
    // https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.SetSelectedGameObject.html
    EventSystem m_EventSystem;
    void OnEnable()
    {
        //Fetch the current EventSystem. Make sure your Scene has one.
        m_EventSystem = EventSystem.current;
    }

    private void Update()
    {
        Debug.Log("Current selected GameObject : " + m_EventSystem.currentSelectedGameObject);
        Debug.Log("OUTPUT SELECTED : ");
    }





    */

}



/*
 * Another way of handling this ; note to self;
            abilityTwo.enabled = true;
            abilityTwo.GetComponentInChildren<Text>().enabled = true;
            abilityTwo.GetComponent<Image>().enabled = true;
            abilityTwo.Select();

            abilityOne.enabled = false;
            abilityOne.GetComponentInChildren<Text>().enabled = false;
            abilityOne.GetComponent<Image>().enabled = false;
*/
