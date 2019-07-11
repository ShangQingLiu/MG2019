using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingState : MonoBehaviour {
	
    private bool floatUp = false;
    private Rigidbody rb;
    private int i = 0;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //InvokeRepeating("floater", 1, 3);
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0.02f*Mathf.Sin(Time.time),0);
    }

    
}
