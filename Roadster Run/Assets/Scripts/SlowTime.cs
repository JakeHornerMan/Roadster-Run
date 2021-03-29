using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    private IEnumerator coroutine;

    public float slomolength;
    public float rechargelength;

    public bool rechargetime;

    public bool slowmoable;

    public void Awake(){
        slowmoable = true;
        rechargetime= false;
        slomolength = 2f;
        rechargelength = 5f;
    }

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

    private void Slow(){
        slowmoable = false;
        Time.timeScale = 0.7f;
        coroutine = waitfornormalTime(slomolength);
        StartCoroutine(coroutine);
    }

    IEnumerator waitfornormalTime(float _waitTime) {
        yield return new WaitForSeconds(_waitTime);
        Normal();
    }
    public void Normal(){
        Time.timeScale = 1;
        coroutine = rechargeSlowmo(rechargelength);
        StartCoroutine(coroutine);
    }

    IEnumerator rechargeSlowmo(float _waitTime) {
        rechargetime = true;
        yield return new WaitForSeconds(_waitTime);
        slowmoable = true;
        rechargetime = false;
    }
}
