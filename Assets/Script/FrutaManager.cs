using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrutaManager : MonoBehaviour
{
    public void Update()
    {
        ColeccionTodasDeFrutas();
    }

    public void ColeccionTodasDeFrutas()
    {
        if (transform.childCount == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //carga una scena
        }
    }
}
