using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPosition_X, checkPointPosition_Z;



    // Comprueba si en ReachedCheckPoint hay valores registrados entonces lleva a player a esas
    // coordenadas
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPosition_X") != 0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPosition_X"), PlayerPrefs.GetFloat("checkPointPosition_Y")));
        }
        
    }

    // Guarda coordenadas del checkPoint con PlayerPrefs --no guarda vectores
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPosition_X", x);
        PlayerPrefs.SetFloat("checkPointPosition_Y", y);
    }
}
