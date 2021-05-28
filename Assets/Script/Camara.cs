using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform objetivo; //player
    public Vector3 offset; //ajuste de camara
    public float suavizarCam = 0.125f;
    Vector3 velocidad = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 posDeseada = objetivo.position + offset;
        Vector3 posSuavizada = Vector3.SmoothDamp(transform.position, posDeseada, ref velocidad, suavizarCam);
        transform.position = posSuavizada;
    }
}