using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStateControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//enable zeroGravity
        if (!GetComponent<CubeFloatingInit>().enabled)
        {
            if (Globals.worldState == Globals.state.ZEROGRAVITY)
            {
                GetComponent<CubeFloatingInit>().enabled = true; 
            }
        }
	}
}
