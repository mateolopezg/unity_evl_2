using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //detecta si player toco el checkpoint y ejecuta evento
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
        }
    }
}
