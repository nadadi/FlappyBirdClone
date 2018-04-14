using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float speed = 3f;
    public PlayAudio playAudio;
    private Rigidbody2D myRigidbody;

    //Se ejecuta antes de cargar el nivel.
    private void Awake()
    {
        //Obtenemos el componente de Rigidbody asociado al objeto y lo asignamos a nuestra variable.
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.gravityScale = 0f;
    }

    //Se ejecuta luego de cargar el nivel.
    private void Start()
    {
        //myRigidbody.velocity = new Vector2(speed, 0f);
    }

    //Se ejecuta X cantidad de veces por segundo (depende de la tasa de frecuencia de la pantalla y procesador).
    private void Update()
    {
        //Preguntamos por cada frame si el jugador presionó el click izquierdo del mouse.
        if (Input.GetMouseButtonDown(0))
        {
            //Frenamos al personaje primero.
            myRigidbody.velocity = new Vector2(speed, 0f);
            //Luego le asignamos al Rigidbody una fuerza impulso hacia arriba cambiando su velocidad.
            myRigidbody.velocity = new Vector2(speed, jumpForce);
            //Ejecutamos el audio del salto.
            playAudio.ExecuteAudio();
            //Si es la primera vez que el jugador presiona el botón, entonces comienza el juego.
            if (myRigidbody.gravityScale == 0f)
                myRigidbody.gravityScale = 1f;
        }
    }
}
