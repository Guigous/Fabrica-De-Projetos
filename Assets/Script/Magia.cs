using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magia : MonoBehaviour
{

    public float customana;
    private void Start()
    {
        StartCoroutine(destroyBullet());
    }

    void Update()
    {
        transform.Translate(Vector2.up * 10 * Time.deltaTime);

    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }

    
}
