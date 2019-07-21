using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStateController : MonoBehaviour {

    //init instance
    Rigidbody rb;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Globals.worldState);
        if (Globals.timeStop) {
            rb.mass = 50;
            return;
        }

        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                rb.mass = 20000;
                break;
            case Globals.state.INVERT:
                rb.mass = 20000;
                break;
            case Globals.state.ZEROGRAVITY:
                rb.mass = 20;
                break;
        }
    }

}
