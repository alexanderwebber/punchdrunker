using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TK wrote all of this / old version;

public class MainMenu : MonoBehaviour
{

    /*
     * this script will deal with functions and code
     * relating specifically to things that happen in the main menu
     * 
     * for example, we are going to reset our playerprefs to the starting settings
     * in the start function, because we don't want to continue 
     * where we left off every time the game is opened
     */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MenuQuitGame()
    {
        Debug.Log("The Game is Exiting.");
        Application.Quit();
    }


    /*
     * here is some examples of calling other scripts from this script
     */

    // METHOD A:

    // you have to drag the SceneChanger GameObject
    // int the 'scene changer' slot in the inspector of the object
    // this script is attached to
    public SceneChanger sceneChanger;

    public void MethodA()
    {
        // calls ChangeSceneExample function from SceneChanger script
//        sceneChanger.GoGameOver();
        sceneChanger.GoSceneNumber(4);
    }

    // METHOD B:
    // make sure both scripts you want to use are attached
    // as components to the calling object (a button in this case)
    // ie. SceneChanger script added to button as component to use this
    public void MethodB()
    {
        FindObjectOfType<SceneChanger>().GoGameOver();
    }

    // METHOD B:
    // drag SceneChanger OBJECT into scene
    public void MethodC()
    {
        // drag SceneChanger OBJECT into scene
        FindObjectOfType<SceneChanger>().ChangeSceneExample();
        // this will only work if object in scene 
        // because there is a coroutine to it
    }

}
