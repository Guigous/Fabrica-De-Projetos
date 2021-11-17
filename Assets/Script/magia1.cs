using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magia1 : MonoBehaviour
{
    public float tempodevida;
    private float tempoCorrente;
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        transform.Translate(velocidade * Time.deltaTime, 0, 0);
        tempoCorrente += Time.deltaTime;
        if (tempoCorrente >= tempodevida)
        {
            Destroy(gameObject);
        }
    }


    public void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}