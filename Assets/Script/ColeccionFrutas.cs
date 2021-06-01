using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionFrutas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false; //desactiva la manzana
            gameObject.transform.GetChild(0).gameObject.SetActive(true); //activa primer Child del objeto manzana osea la animación
            
            //FindObjectOfType<FrutaManager>().ColeccionTodasDeFrutas(); //consulta si quedan frutas

            Destroy(gameObject, 0.5f);  //destruye la manzana con la animacion una vez coleccionada 
        }
    }
}
