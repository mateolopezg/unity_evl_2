using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto = 400f; //cantidad de fuerza personaje saltando
    [SerializeField] private bool controlAire = false; // dcidir si puede modificar salto en el aire
    [SerializeField] private LayerMask queEsPiso; //determina si es piso
    [SerializeField] private Transform chequeoPiso;
    [Range(0,1f)] [SerializeField] private float suavizarMove = 0.05f; //[SerializeField crea barrita en  inspector]]suavizar movimiento
    
    private bool miraDerecha = true; 
    private Vector3 velocidad = Vector3.zero;
    private Rigidbody2D rb;
    private bool enElPiso;

    public UnityEvent cuandoAterrizoEvento;

    const float radioChequeo = 2f; //radio del circulo esPiso

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //obtiene personaje

        if(cuandoAterrizoEvento == null){
            cuandoAterrizoEvento = new UnityEvent();

        }
    }

    private void FixedUpdate()
    {
        bool estabaEnPiso = enElPiso;
        enElPiso = false;
        Collider2D[] col2D = Physics2D.OverlapCircleAll(chequeoPiso.position, radioChequeo, queEsPiso); //genera circulo donde esta piso de 2f (radioChequeo), QUE ES PISO define piso
        for (int i = 0; i < col2D.Length; i++)
        {
            if(col2D[i].gameObject != gameObject)
            {
                enElPiso = true;
                if(!estabaEnPiso){
                    cuandoAterrizoEvento.Invoke(); //convoca evento cuando no estaba en piso
                }
            }
        }
    }

    public void Mover(float mover, bool salto)
    {
        //Mover player con velocidad objetivo
        Vector3 velocidadObjetivo = new Vector2(mover * 10f, rb.velocity.y); //x, y

        //Suavizar personaje
        // SmoothDamp: Gradualmente cambia el vector hacia la meta deseada mientras pasa el tiempo
        rb.velocity = Vector3.SmoothDamp(rb.velocity, velocidadObjetivo, ref velocidad, suavizarMove); 

        //determina lugar de mira
        if(mover > 0 && !miraDerecha)
        {
            //voltea
            Flip();
        }
        else if(mover < 0 && miraDerecha){
            Flip();
        }

        if(enElPiso && salto)
        {
            enElPiso = false;
            rb.AddForce(new Vector2(0f, fuerzaSalto));
        }
    }

    private void Flip()
    {
        //cambia valor primario del bool
        miraDerecha = !miraDerecha;

        //Multiplica la escala en x por -1 para cambiar de lado
        Vector3 _scale = transform.localScale;
        _scale.x *=  -1;
        transform.localScale = _scale;
    }

    

    /*
    void Scale()
    {
        if(Input.GetKey("d"))
        {
            this.transform.localScale = new Vector3(4,4,4);
            
        } 
        if(Input.GetKey("a"))
        {
            this.transform.localScale = new Vector3(-4,4,-4);
            
        } 
    }*/
}
