using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TK wrote this ; old version tho

public class AutoSceneChange : MonoBehaviour
{

    public SceneChanger sceneChanger;
    public SavePrefs savePrefs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSceneChange());
    }

    // Update is called once per frame
    void Update()
    {
/*
        if (Input.anyKey)
        {
            Debug.Log("RETURNING TO GAME'S MAIN MENU!");
            sceneChanger.GoMainMenu();
        }
*/
    }

    IEnumerator WaitSceneChange()
    {
        Debug.Log("Resetting Player Prefs Values.");
        yield return new WaitForSeconds(2);
        Debug.Log("RETURNING TO GAME'S MAIN MENU!");
        sceneChanger.GoMainMenu();
    }
}
