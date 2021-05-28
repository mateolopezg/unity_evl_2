using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemiga : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float rangoAgro;

    Rigidbody2D rb2D;

    public float velocidadMov;
    public Animator animator;

    private bool miraDerecha;

    // Start is called before the first frame update
    void Start()
    {
        miraDerecha = true;
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distancia hasta el judadors
        float distJugador = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distancia del jugador: " + distJugador);

        if(distJugador < rangoAgro && Mathf.Abs(distJugador) > 1)
        {
            perseguir(); //persigue al jugador por distancia obtenida
            animator.SetFloat("Velocidad", 1);
            animator.SetBool("Atacar", false);
        }
        else if(Mathf.Abs(distJugador) < 1)
        {
            animator.SetBool("Atacar", true);
        }
        else{
            noPerseguir();
        }
    }

    private void noPerseguir()
    {
        rb2D.velocity = Vector2.zero;
    }

    private void perseguir(){
        
        if (transform.position.x < player.position.x && !miraDerecha)
        {
            rb2D.velocity = new Vector2(velocidadMov,0f);
            Flip();
        }
        else if(transform.position.x > player.position.x && miraDerecha)
        {
            rb2D.velocity = new Vector2(-velocidadMov, 0f);
            Flip();
        }
        else if(!miraDerecha)
        {
            rb2D.velocity = new Vector2(-velocidadMov, 0f);
        }
        else if (miraDerecha)
        {
            rb2D.velocity = new Vector2(velocidadMov, 0f);
        }
    }

    private void Flip()
    {
        // Defino nuevamente hacia donde esta mirando el jugador
        miraDerecha = !miraDerecha;

        // Multiplicar la escala en X del personaje por -1
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;
    }
}
