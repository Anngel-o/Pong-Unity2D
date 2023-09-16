using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 7f;
    public bool isPaddle1;
    public float paddleLimit = 3.5f;
    private Rigidbody2D palletRB;

    // Start is called before the first frame update
    void Start()
    {
        palletRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement;
        if (isPaddle1)
        {
            movement = Input.GetAxis("Vertical");
        }
        else
        {
            movement = Input.GetAxis("Vertical2");
        }
        palletRB.velocity = new Vector2(palletRB.velocity.x, movement * speed);
        //Matf.Clamp nos ayudará a que la posición en y de nuestra palletRB se encuentre entre los 
        //limites marcados por paddleLimit
        //Math.Clamp(valor a restringir, posición restringida -y, posición restringida y);
        palletRB.position = new Vector2(palletRB.position.x, Mathf.Clamp(palletRB.position.y,-paddleLimit,paddleLimit));
    }
}
