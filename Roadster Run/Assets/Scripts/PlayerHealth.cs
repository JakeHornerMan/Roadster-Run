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
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    public void takeDamage(float inputDamage)
    {
        health -= inputDamage;
        if (health <= 0)
        {
            DeathAnim();
            
            //FindObjectOfType<GameManager>().GameOver();  
        }
    }

    public void DeathAnim(){
        flip();
        explosion();
        coroutine = waitandGameover(2f);
        StartCoroutine(coroutine);
    }

    public void flip(){
        float strength = Random.Range(30f,40);
        this.transform.Rotate(strength, 0.0f, 0.0f, Space.World);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y*10, rb.velocity.z);
    }
    public void explosion(){
        boom.Play();
        ex1.Play();
        ex2.Play();
        ex3.Play();
    }
    IEnumerator waitandGameover(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        FindObjectOfType<GameManager>().GameOver(); 
    }
}
