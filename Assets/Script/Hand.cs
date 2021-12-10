using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mage, spawnerMagePos;
    [SerializeField] float movespeed;
    public float mana,manatual;
    public float  customagia = 10;
    public float manaregen = 1f;
    void Start()
    {
       
    }

    
    //Update is called once per frame
    void Update()
    {
        float tempoespera;
        
        //transform.Translate(move * Time.deltaTime * movespeed);

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;
        tempoespera = Time.deltaTime;

       if (Input.GetMouseButtonDown(0) && manatual > 0 )
        {
            Instantiate(mage, spawnerMagePos.transform.position, this.gameObject.transform.rotation);
            manatual = manatual - customagia;
            
        }
       if(manatual < 50)
        {
            InvokeRepeating("ManaRegen", 1, 1);
        }
       if(manatual >= 50)
        {
            CancelInvoke("ManaRegen");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
    private void ManaRegen()
    {
        manatual += manaregen;
    }
    
   
}
