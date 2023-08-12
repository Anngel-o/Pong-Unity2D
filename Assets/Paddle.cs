using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D palletRB;

    // Start is called before the first frame update
    void Start()
    {
        palletRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Vertical");
        palletRB.velocity = new Vector2(palletRB.velocity.x, movement * speed);
    }
}
