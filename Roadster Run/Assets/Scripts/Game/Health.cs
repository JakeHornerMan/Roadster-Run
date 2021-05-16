using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private IEnumerator coroutine;
    public float health;
    private Rigidbody rb;
    private Collider col;
    public  GameObject player;
    public  GameObject deathColisionObj;
    public ParticleSystem boom;
    public ParticleSystem ex1;
    public ParticleSystem ex2;
    public ParticleSystem ex3;

    private Color alphaColor;
    private float timeToFade = 3f;

    void Start()
    {
        //getting rigibody
        rb = gameObject.GetComponent<Rigidbody>();
        //getting box collider
        col = gameObject.GetComponent<BoxCollider>();
        col.isTrigger = false;
        //finding the player object
        player = GameObject.Find("Player");
        //finding the death collision object
        deathColisionObj = GameObject.Find("CollisionDeath");
        //for fade function
        alphaColor = this.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;
    }

    //called by damage dealing objects
    public void takeDamage(float inputDamage)
    {
        health -= inputDamage;
        if (health <= 0) //when health hits 0
        {
            DeathReations();  
        }
    }

    //playing all object death requirements
    public void DeathReations()
    {
        //ignoring the player object so they do not collide
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        //ignoring the death collision object so they do not collide
        Physics.IgnoreCollision(deathColisionObj.GetComponent<Collider>(), GetComponent<Collider>());
        flip();
        explosion();
        fade();
        coroutine = waitandRemove(3f);
        StartCoroutine(coroutine);
    }

    //randomly generates a flip
    public void flip(){
        float strength = Random.Range(30f,50);
        this.transform.Rotate(strength, 0.0f, 0.0f, Space.World);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y*strength, rb.velocity.z);
    }

    //plays the explosion particles systems
    public void explosion(){
        boom.Play();
        ex1.Play();
        ex2.Play();
        ex3.Play();
    }

    // work in progress in makeing dead enemy object fade out of smoother destroy transition
    public void fade(){
        this.GetComponent<MeshRenderer>().material.color = 
            Color.Lerp(this.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);
    }

    //delete destroyed object to free memory (performance)
    IEnumerator waitandRemove(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        Destroy(gameObject);
    }
}
