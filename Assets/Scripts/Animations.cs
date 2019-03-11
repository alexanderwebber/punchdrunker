using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * the only thing this class does is contain functions
 * that start animations
 */

public class Animations : MonoBehaviour
{
    // Define any objects/components you need here
    // then drag it into the section of the inspector
    // so that it can be used
    Animator PlayerAnimator;
    Animator EnemyAnimator;

    // example function:
    public void PlayerPunchAnimation()
    {
        // PlayerAnimator.SetTrigger("nameoftriggerhere");
    }



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


}
