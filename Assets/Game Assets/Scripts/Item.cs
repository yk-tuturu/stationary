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
    
    [SerializeField] private bool inRange = false;

    public int index = 1;
    private bool isActive = true;

    void Start() {
        rb.velocity = Vector2.down * speed;
    }


    void Update()
    {

        if (inRange) {
            if (Input.GetKeyDown(KeyCode.A)){
                moveLeft();
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                moveRight();
            }
        }
    }

    private void FixedUpdate()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            if (collision.gameObject.GetComponent<Box>().index == index)
            {
                success();
            }
            else
            {
                fail();
            }
        }

        if (collision.tag == "Scanner") {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Scanner") {
            inRange = false;
        }
    }

    void moveLeft()
    {
        Debug.Log("move left");
        rb.velocity = Vector2.left * 20f;
    }
    void moveRight()
    {
        rb.velocity = Vector2.right * 20f;
    }

    void success()
    {
        rb.velocity = Vector2.zero;
        GameManager.instance.updateScore(100);
        LeanTween.scale(gameObject, Vector3.zero, 0.3f);
    }
    void fail()
    {
        rb.velocity = Vector2.zero;
        GameManager.instance.decreaseHealth();
        LeanTween.scale(gameObject, Vector3.zero, 0.3f);
    }
}
