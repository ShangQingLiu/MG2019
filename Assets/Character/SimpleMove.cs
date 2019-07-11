using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 
            Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, 0);

	}
}
