using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    public float moveSpeed = 10f;
    public Vector2 direction;
    public Rigidbody2D rb;
    public Animator animator;
    public float maxSpeed = 7f;
    public float linearDrag = 4f;



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }



    void Update()

    {
        
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        moveCharacter(direction.x);
        moveCharacterUP(direction.y);
    }
    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);
        

    }
    void moveCharacterUP(float vertical)
    {
        rb.AddForce(Vector2.up * vertical * moveSpeed);


    }

}
