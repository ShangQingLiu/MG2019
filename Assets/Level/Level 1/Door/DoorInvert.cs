using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInvert : MonoBehaviour {

    public GameObject normalPosition;
    public GameObject invertPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                transform.rotation = new Quaternion(0,0,0,0);
                transform.position = normalPosition.transform.position;
                break;
            case Globals.state.INVERT:
                transform.rotation = new Quaternion(0, 0, 180, 0);
                transform.position = invertPosition.transform.position;
                break;
            case Globals.state.ZEROGRAVITY:
                break;
        }
	}
}
