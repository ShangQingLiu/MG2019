using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody rigid;
	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody>();
            Debug.Log(Globals.worldState);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical   = Input.GetAxis("Vertical");
        if (Globals.worldState != Globals.state.ZEROGRAVITY)
            Vertical = 0.0f;
            

        Vector3 move = new Vector3(Horizontal, Vertical, 0.0f);

        //rigid.AddForce(move * speed);
        if (rigid.velocity.magnitude > 50)
            rigid.velocity =move.normalized * 50;
        else
            rigid.velocity += move * speed;

        if (!this.GetComponent<FloatingState>().enabled)
        {
            if (Globals.worldState == Globals.state.ZEROGRAVITY)
            {
                this.GetComponent<FloatingState>().enabled = true; 
            }
        }

	}
}
