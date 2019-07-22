using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D _body;
    // Use this for initialization
    void Start() {
        
        Debug.Log(Globals.worldState);
        _body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate() {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        if (Globals.worldState != Globals.state.ZEROGRAVITY)
            Vertical = 0.0f;


        Vector2 move = new Vector2(Horizontal, Vertical);
        if (_body.velocity.magnitude > 100)
            _body.velocity = _body.velocity.normalized * 100;
        else
            _body.velocity += move * speed;

    }
}
