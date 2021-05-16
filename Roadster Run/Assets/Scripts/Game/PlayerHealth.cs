using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    private Rigidbody rb;
    
    private IEnumerator coroutine;

     //particles
    public ParticleSystem boom;
    public ParticleSystem ex1;
    public ParticleSystem ex2;
    public ParticleSystem ex3;

    

    // Start is called before the first frame update
    void Start()
    {
        //getting rigidbody component
        rb = gameObject.GetComponent<Rigidbody>();
    }

    //called by object or function that hurts the player
    public void takeDamage(float inputDamage)
    {
        health -= inputDamage;
        if (health <= 0)
        {
            //plays death reactions
            DeathAnim();
        }
    }

    //death reaction are fliping car, playing the explosion particle systems, and setting gameover screnn to show
    public void DeathAnim(){
        flip();
        explosion();
        coroutine = waitandGameover(2f);
        StartCoroutine(coroutine);
    }

    //randomly generated flips
    public void flip(){
        float strength = Random.Range(30f,40);
        this.transform.Rotate(strength, 0.0f, 0.0f, Space.World);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y*10, rb.velocity.z);
    }

    //playing explosion particle systems
    public void explosion(){
        boom.Play();
        ex1.Play();
        ex2.Play();
        ex3.Play();
    }
    
    //gameover screen show after 2 seconds
    IEnumerator waitandGameover(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        FindObjectOfType<GameManager>().GameOver(); 
    }
}
