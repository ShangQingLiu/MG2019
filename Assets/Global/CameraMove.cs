using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject leftBoundary;
    public GameObject midPosition;
    public GameObject rightBoundary;
    public GameObject player;

    public float moveSpeed;
    public float cameraHalfWidth;

    private Vector3 _cameraMove;
	// Use this for initialization
	void Start () {
        _cameraMove = new Vector3(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        //if(player.transform.position.x > leftBoundary.transform.position.x
        //    && player.transform.position.x < rightBoundary.transform.position.x)
        //    transform.position = new Vector3(player.transform.position.x,
        //        transform.position.y, transform.position.z);
       
        if(distance() < cameraHalfWidth) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.position -= new Vector3(moveSpeed, 0, 0);
            }else if (Input.GetKey(KeyCode.RightArrow)) {
                transform.position += new Vector3(moveSpeed, 0, 0);
            }
        }
        else {
            if(transform.position.x < player.transform.position.x)
                transform.position += new Vector3(moveSpeed, 0, 0);
            else
                transform.position -= new Vector3(moveSpeed, 0, 0);
        }

        if (!Boundary()) {
            if (transform.position.x < midPosition.transform.position.x)
                transform.position += new Vector3(moveSpeed, 0, 0);
            else
                transform.position -= new Vector3(moveSpeed, 0, 0);
        }
        
	}

    private bool Boundary() {
        return (transform.position.x - moveSpeed > leftBoundary.transform.position.x)
            && (transform.position.x + moveSpeed < rightBoundary.transform.position.x);
    }

    private float distance() {
        return Mathf.Abs(transform.position.x - player.transform.position.x);
    }
}
