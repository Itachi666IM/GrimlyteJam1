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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if(drown)
        {
            StartCoroutine(StartDrown());   
        }
    }

    IEnumerator StartDrown()
    {
        rb.velocity = Vector2.down * speed * Time.deltaTime;
        yield return new WaitForSeconds(drownTime);
        drown = false;
    }

}
