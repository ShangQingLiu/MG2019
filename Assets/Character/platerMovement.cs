using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody _body;
    //private Rigidbody2D rigid2d;
	// Use this for initialization
	void Start () {

        //rigid = GetComponent<Rigidbody>();
            Debug.Log(Globals.worldState);
        _body = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical   = Input.GetAxis("Vertical");
        if (Globals.worldState != Globals.state.ZEROGRAVITY)
            Vertical = 0.0f;
            

        Vector3 move = new Vector3(Horizontal, Vertical,0);

        //rigid.AddForce(move * speed);
        if (_body.velocity.magnitude > 50)
            _body.velocity = _body.velocity.normalized * 50;
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
