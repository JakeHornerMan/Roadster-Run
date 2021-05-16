using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    private IEnumerator coroutine;

    private float slomolength;
    private float rechargelength;

    private bool rechargetime;

    private bool slowmoable;

    //setting all switches to correct place to also initial Slow() function
    public void Awake(){
        slowmoable = true;
        rechargetime= false;
        slomolength = 2f;
        rechargelength = 5f;
    }

    //function for button press
    public void SlowmoSwitch(){
        if(slowmoable == true && rechargetime == false){
            Slow();
        }
        else if(slowmoable == false && rechargetime == false){
            Normal();
        }
        else if(slowmoable == false && rechargetime == true){

        }
    }

    //slows time down
    private void Slow(){
        slowmoable = false;
        Time.timeScale = 0.7f;
        coroutine = waitfornormalTime(slomolength); //starts timer for slow motion
        StartCoroutine(coroutine);
    }

    //after timer run Normal()
    IEnumerator waitfornormalTime(float _waitTime) {
        yield return new WaitForSeconds(_waitTime);
        Normal();
    }

    //sets time to normal 
    public void Normal(){
        Time.timeScale = 1;
        coroutine = rechargeSlowmo(rechargelength); //starts timere for recharge of the slow ability
        StartCoroutine(coroutine);
    }

    //recharge nullifys any press of the Slow Motion button
    IEnumerator rechargeSlowmo(float _waitTime) {
        rechargetime = true;
        yield return new WaitForSeconds(_waitTime); // after timer player is allowed provoke Slow Motion
        slowmoable = true;
        rechargetime = false;
    }
}
