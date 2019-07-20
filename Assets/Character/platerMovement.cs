using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody rigid;
    private Rigidbody2D _body;
	// Use this for initialization
	void Start () {

        //rigid = GetComponent<Rigidbody>();
            Debug.Log(Globals.worldState);
        _body = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical   = Input.GetAxis("Vertical");
        if (Globals.worldState != Globals.state.ZEROGRAVITY)
            Vertical = 0.0f;
            

        Vector2 move = new Vector2(Horizontal, Vertical);

        //rigid.AddForce(move * speed);
        if (_body.velocity.magnitude > 50)
            _body.velocity =move.normalized * 50;
        else
            _body.velocity += move * speed;

        //if (!this.GetComponent<FloatingState>().enabled)
        //{
        //    if (Globals.worldState == Globals.state.ZEROGRAVITY)
        //    {
        //        this.GetComponent<FloatingState>().enabled = true; 
        //    }
        //}

	}
}
