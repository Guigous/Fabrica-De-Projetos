using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject mage, spawnerMagePos;
    Vector2 move;
    [SerializeField] float movespeed;
    public int health,vidafull;
    public int custovida;
    public GameObject gameover;
    private bool m_FacingRight = true;

    public Rigidbody2D rigidbody;

        // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        rigidbody.AddForce(move * Time.deltaTime * movespeed, ForceMode2D.Force);

        rigidbody.velocity = rigidbody.velocity / 1.0025f;

        if (move.x > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move.x < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

       
        
    }


	private void Flip()
    {
    // Switch the way the player is labelled as facing.
    m_FacingRight = !m_FacingRight;

    // Multiply the player's x local scale by -1.
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (health > 0 )
            {
                health -= custovida;
            }

            if (health <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        health = 0;

        gameover.SetActive(true);
        gameObject.SetActive(false);
    }
}

