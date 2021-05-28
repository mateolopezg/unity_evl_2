using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlChico : MonoBehaviour
{
    public ControlPlayer controlador;
    public float veloCorrer = 40f;
    public Animator animator;

    float movH = 0f;
    bool salto = false;


    // Tomamos el valor presionado
    void Update()
    {
        movH = Input.GetAxisRaw("Horizontal") * veloCorrer;
        animator.SetFloat("Velocidad",Mathf.Abs(movH));
        
        if(Input.GetButtonDown("Jump") || Input.GetKey ("w")){
            salto = true;
            animator.SetBool("EstoySaltando", true);
        }
    }

    //FixedUpdate aplicamos el mov del player
    private void FixedUpdate()
    {
        controlador.Mover(movH * Time.fixedDeltaTime, salto);
        salto = false;
    }

    public void CuandoPiso()
    {
        animator.SetBool("EstoySaltando", false);
    }
}
