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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultSpeed = speed;
        spawner = FindObjectOfType<Spawner>();
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
        }
        if (hasSlowPower)
        {
            hasSlowPower = false;
            Instantiate(slowEffect, transform.position, transform.rotation);
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
