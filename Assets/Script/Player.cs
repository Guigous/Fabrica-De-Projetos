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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        transform.Translate(move * Time.deltaTime * movespeed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log(health);
            if (health > 0 )
            {
                health -= custovida;
            }
            if (health<=0) 
            {
                gameObject.SetActive(false);
                gameover.SetActive(true);
                
            }
                
        }
    }
}

