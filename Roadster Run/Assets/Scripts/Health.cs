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
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<BoxCollider>();
        col.isTrigger = false;
        player = GameObject.Find("Player");
        deathColisionObj = GameObject.Find("CollisionDeath");
        alphaColor = this.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;
    }

    void Update()
    {
        
    }

    public void takeDamage(float inputDamage)
    {
        health -= inputDamage;
        if (health <= 0)
        {
            DeathReations();  
        }
    }

    public void DeathReations()
    {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(deathColisionObj.GetComponent<Collider>(), GetComponent<Collider>());
        //col.isTrigger = true;
        flip();
        explosion();
        fade();
        coroutine = waitandRemove(3f);
        StartCoroutine(coroutine);
    }
    public void flip(){
        float strength = Random.Range(30f,50);
        this.transform.Rotate(strength, 0.0f, 0.0f, Space.World);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y*strength, rb.velocity.z);
    }
    public void explosion(){
        boom.Play();
        ex1.Play();
        ex2.Play();
        ex3.Play();
    }
    public void fade(){
        this.GetComponent<MeshRenderer>().material.color = 
            Color.Lerp(this.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);
    }
    IEnumerator waitandRemove(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        Destroy(gameObject);
    }
}
