using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvert : MonoBehaviour {

    public GameObject normalPosition;
    public GameObject invertPosition;

    private Vector3 curRotation;
    private Rigidbody2D _body;

	// Use this for initialization
	void Start () {
        curRotation = new Vector3(0, 0, 0);
        _body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                State_Normal();
                break;
            case Globals.state.INVERT:
                State_Invert();
                break;
            case Globals.state.ZEROGRAVITY:
                State_Zerogravity();
                break;
        }
	}
    
    private void State_Normal() {
        if (Input.GetKeyDown(KeyCode.A))
            curRotation.y = 180;
        else if (Input.GetKeyDown(KeyCode.D))
            curRotation.y = 0;
        curRotation.z = 0;
        //transform.position = new Vector3(transform.position.x,
        //    normalPosition.transform.position.y,
        //    transform.position.z);
        _body.gravityScale = Globals.gravity2D;
        transform.localEulerAngles = curRotation;
    }

    private void State_Invert() {
        if (Input.GetKeyDown(KeyCode.A))
            curRotation.y = 0;
        else if (Input.GetKeyDown(KeyCode.D))
            curRotation.y = 180;
        curRotation.z = 180;
        //transform.position = new Vector3(transform.position.x,
        //    invertPosition.transform.position.y,
        //    transform.position.z);
        _body.gravityScale = -Globals.gravity2D;
        transform.localEulerAngles = curRotation;
    }

    private void State_Zerogravity() {
        if (Input.GetKeyDown(KeyCode.A))
            curRotation.y = 180;
        else if (Input.GetKeyDown(KeyCode.D))
            curRotation.y = 0;
        curRotation.z = 0;
        _body.gravityScale = 0;
        transform.localEulerAngles = curRotation;
    }
}
