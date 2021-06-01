using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPinxo : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
        }
        Debug.Log("Daño al Chico");
        Destroy(collision.gameObject);
    }
}
