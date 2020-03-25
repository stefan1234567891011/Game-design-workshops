using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //public float speed;

    //private Rigidbody2D rb;

    public UnityEvent EnemyTouchedEvent = new UnityEvent();

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.x -= 0.1f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x += 0.1f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y += 0.1f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.y -= 0.1f;
            this.transform.position = position;
        }
    }

    /*
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed);
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyTouchedEvent.Invoke();
    }
}
