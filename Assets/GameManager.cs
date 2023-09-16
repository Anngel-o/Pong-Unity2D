//Librería para manipular objetos de tipo Text en Unity
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables para almacenar las cajas de texto de puntos y poder actualizarlas con el puntaje real
    public TMP_Text paddle1Text;
    public TMP_Text paddle2Text;
    //Creamos dos variables acumuladoras para ir almacenando el puntaje de las paletas
    public int paddle1Score = 0;
    public int paddle2Score = 0;
    //Creamos variables tipo RigidBody2D para hacer referencias a los rb de la bola y las paletas
    //para después poder manipular sus posiciones 
    public Rigidbody2D ballRB;
    public Rigidbody2D paddle1RB;
    public Rigidbody2D paddle2RB;

    public void Paddle1Score() {
        //Sumamos un punto a la paleta 1
        paddle1Score++;
        //Para asignarle el puntaje acumulado a la caja de texto debemos convertir el puntaje
        //a tipo texto con el método ToString().
        paddle1Text.text = paddle1Score.ToString();
    }
    //Hacemos lo mismo para el puntaje de la paleta 2
    public void Paddle2Score() {
        //Sumamos un punto a la paleta 2
        paddle2Score++;
        //Para asignarle el puntaje acumulado a la caja de texto debemos convertir el puntaje
        //a tipo texto con el método ToString().
        paddle2Text.text = paddle2Score.ToString();
    }

    public void Restart() {
        //Creamos un método para regresar a la bola a su posición original y las paletas deberemos
        //regresarlas a 0 en el eje y, y dejar su posición en x intacta ya que no la utilizamos
        ballRB.position = new Vector2(0,0);
        paddle1RB.position = new Vector2(paddle1RB.position.x,0);
        paddle2RB.position = new Vector2(paddle2RB.position.x,0);
    }
}
