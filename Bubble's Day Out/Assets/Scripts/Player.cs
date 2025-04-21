using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
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
        else
        {
            drown = false;
        }
    }

    private void Update()
    {
        if(drown)
        {
            rb.velocity = Vector2.down * speed * Time.deltaTime;
        }
    }

}
