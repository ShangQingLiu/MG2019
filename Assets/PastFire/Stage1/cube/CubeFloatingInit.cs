using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFloatingInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y < 160f)
        {
        transform.position = transform.position + new Vector3(0,1f,0);
        }
        else
        {
        transform.position = transform.position + new Vector3(0, 0.01f*Mathf.Sin(Time.time),0);
        }
	}
}
