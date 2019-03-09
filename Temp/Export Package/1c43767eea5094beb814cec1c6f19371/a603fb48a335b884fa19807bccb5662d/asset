using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TK wrote all of this; this is an old version:

/*
 * this script will house all the functions needed to change between scenes 
 * with easier to follow names so we don't have to type it out
 * and look up scene numbers every time
 * and we may want to have scripts that have effects or timed delays (IENumerator)
 * though that may end up elsewhere depending on how we want to organize it
 * 
 */

public class SceneChanger : MonoBehaviour
{
    // Exit the game from Main Menu
    public void MenuQuitGame()
    {
        Debug.Log("The Game is Exiting.");
        Application.Quit();
    }

    // Load scene by number in build order
    public void GoSceneNumber(int num)
    {
        Debug.Log("Loading Scene Number " + num + ".");
        SceneManager.LoadScene(num);
    }

    // WARNING!!!!!!!!!!!!!!!
    // If you rename any of the scenes 
    // these functions will not work anymore:

    public void GoMainMenu()
    {
        Debug.Log("Loading Main Menu.");
        SceneManager.LoadScene("0MainMenu");
    }

    public void GoGameOver()
    {
        Debug.Log("Loading Game Over.");
        SceneManager.LoadScene("1GameOver");
    }

    public void GoBeatGame()
    {
        Debug.Log("Loading Beat Game.");
        SceneManager.LoadScene("2BeatGame");
    }

    public void GoCredits()
    {
        Debug.Log("Loading Credits.");
        SceneManager.LoadScene("3Credits");
    }

    public void GoGymMenu()
    {
        Debug.Log("Loading GymMenu.");
        SceneManager.LoadScene("4GymMenu");
    }

    public void GoMatch()
    {
        Debug.Log("Loading Match.");
        SceneManager.LoadScene("5Match");
    }

    public void GoSparring()
    {
        Debug.Log("Loading Sparring.");
        SceneManager.LoadScene("6Sparring");
    }

    public void GoRankUp()
    {
        Debug.Log("Loading Rank Up.");
        SceneManager.LoadScene("7RankUp");
    }

    public void GoSpendEXP()
    {
        Debug.Log("Loading Spend EXP.");
        SceneManager.LoadScene("8SpendEXP");
    }


    // ------------------------------------------------------ //











    public void ChangeSceneExample()
    {
        Debug.Log("YOU ARE IN CHANGESCENEEXAMPLE() !");
        //        SceneManager.LoadScene("1GameOver");
        this.StartCoroutine(Timewait());
        // may not need the 'this.' here; i was trying to solve a problem
        // that was solved another way
    }


    // note, for IEnumerators to work they object the script is attached to must be
    // present in the scene; can't just have a prefab
    IEnumerator Timewait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("1GameOver");
    }
}
