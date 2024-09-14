using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    

    [Header("Attributes")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private int index = 1;

    private bool isActive = true;
    


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isActive) return;

        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Scanner")
        {
            
            if (Input.GetKeyDown(KeyCode.A)){
                moveLeft();
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                moveRight();
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<Box>().index == index)
        {
            Debug.Log("Success!");
        }
        else
        {
            Debug.Log("Fail");
        }
    }

    void moveLeft()
    {
        Debug.Log("move left");
        isActive = false;
        rb.velocity = Vector2.left * 20f;
    }
    void moveRight()
    {
        isActive = false;
        rb.velocity = Vector2.right * 20f;
    }

}
