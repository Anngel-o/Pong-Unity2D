using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D ballRB;
    public float initialVelocity = 4f;
    public float velocityMultiplier = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("paddle"))
        {
            //Cada colision detectada con las paletas la velocidad de la bola aumentará según velocityMultiplier,
            //que en este caso tiene un valor de 1.1f, es decir, la bola aumentará un 10% su velocidad cada
            //colisión detectada
            ballRB.velocity *= velocityMultiplier;
        }
    }

    public void Launch() { //Lanzamiento
        float velocityX;
        float velocityY;
        //Random.Range(0, 3) nos dará un valor aleatorio entre 0 y 3, así podremos darle diferentes valores
        //a la velocidad en x & y para después construir un vector con direcciones aleatorias
        float aleatory = Random.Range(0, 3);
        if (aleatory == 0)
        {
            velocityX = 1;
            velocityY = 1;
        } else {
            velocityX = -1;
            velocityY = -1;
        }
        //Agregamos una velocidad a la bola construyendo un vector con dirección determinada aleatoreamente
        ballRB.velocity = new Vector2(velocityX, velocityY) * initialVelocity;
    }

    //Creamos una instancia de nuestra clase GameManager para poder acceder
    //a los métodos que creamos para el puntaje del juego
    public GameManager gameManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goal1"))
        {
            //Sumamos el puntaje de la paleta 2 si se detecta que la bola pasó por la
            //meta 1 (Goal 1 con Tag goal1)
            gameManager.Paddle2Score();
            //Reiniciamos el juego mandando todo a sus posiciones originales de juego
            gameManager.Restart();
            //Lanzamos la bola aleatoreamente con el método que creamos llamado Launch().
            Launch();
        } else {
            //Sumamos el puntaje de la paleta 1 si se detecta que la bola pasó por la
            //meta 2 (sin Tag, pero al entrar en el else detectamos Goal2)
            gameManager.Paddle1Score();
            //Reiniciamos el juego mandando todo a sus posiciones originales de juego
            gameManager.Restart();
            //Lanzamos la bola aleatoreamente con el método que creamos llamado Launch().
            Launch();
        }
    }
}
