using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float drownTime;
    bool drown;
    [HideInInspector]public bool hasSlowPower = false;
    public float slowDownTime;
    [HideInInspector]public float defaultSpeed;

    public GameObject slowEffect;

    [HideInInspector]public bool canReset = false;

    Spawner spawner;

    AudioSource audioSource;
    public AudioClip timeSlow;
    public AudioClip resetSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultSpeed = speed;
        spawner = FindObjectOfType<Spawner>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnDrown(InputValue value)
    {
        if(value.isPressed)
        {
            drown = true;
        }
    }

    private void Update()
    {
        if(canReset==true)
        {
            canReset = false;
            spawner.timeBetweenSpawns = spawner.maxSpawnTime;
            audioSource.PlayOneShot(resetSpeed);
        }
        if (hasSlowPower)
        {
            hasSlowPower = false;
            Instantiate(slowEffect, transform.position, transform.rotation);
            audioSource.PlayOneShot(timeSlow);
        }
    }

    private void FixedUpdate()
    {
        if(drown)
        {
            StartCoroutine(StartDrown());   
        }
    }

    IEnumerator StartDrown()
    {
        rb.velocity = Vector2.down * speed * Time.fixedDeltaTime;
        yield return new WaitForSeconds(drownTime);
        drown = false;
    }
}
