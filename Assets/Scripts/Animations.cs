using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * the only thing this class does is contain functions
 * that start animations
 */

// TK set this up ; notwritten yet

public class Animations : MonoBehaviour
{
    // Define any objects/components you need here
    // then drag it into the section of the inspector
    // so that it can be used
    public Animator PlayerAnimator;
    public Animator EnemyAnimator;

    // example function:
    public void playerJabAnimate()
    {
        // PlayerAnimator.SetTrigger("nameoftriggerhere");
        PlayerAnimator.SetTrigger("doJab");
    }

    public void playerCrossAnimate()
    {
        PlayerAnimator.SetTrigger("doCross");
    }

    public void playerRecoverAnimate()
    {
        PlayerAnimator.SetTrigger("doRecover");
    }
}
