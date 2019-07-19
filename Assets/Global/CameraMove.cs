using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject midPosition;
    public GameObject rightBoundary;
    public GameObject leftBoundary;
    public GameObject topBoundary;
    public GameObject bottomBoundary;
    public GameObject player;
    

    public float moveSpeed;
    public float cameraHalfWidth;
    public float cameraHalfHeight;

    private Vector3 _cameraMove;
    private Camera camera;
	// Use this for initialization
	void Start () {
        _cameraMove = new Vector3(0, 0, 0);
        camera = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        //if(player.transform.position.x > leftBoundary.transform.position.x
        //    && player.transform.position.x < rightBoundary.transform.position.x)
        //    transform.position = new Vector3(player.transform.position.x,
        //        transform.position.y, transform.position.z);
       
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= new Vector3(moveSpeed, 0, 0);
        }else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(moveSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position -= new Vector3(0, moveSpeed, 0);
        }else if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += new Vector3(0, moveSpeed, 0);
        }
        if (!Boundary_x()) {
            if (transform.position.x < midPosition.transform.position.x)
                transform.position += new Vector3(moveSpeed, 0, 0);
            else
                transform.position -= new Vector3(moveSpeed, 0, 0);
        }
        
        if (!Boundary_y()) {
            Debug.Log(transform.position.y);
            Debug.Log(midPosition.transform.position.y);

            if (transform.position.y < midPosition.transform.position.y)
                transform.position += new Vector3(0, moveSpeed, 0);
            else
                transform.position -= new Vector3(0, moveSpeed, 0);
        }
        
	}

    private bool Boundary_x() {
        return (transform.position.x - moveSpeed > leftBoundary.transform.position.x)
            && (transform.position.x + moveSpeed < rightBoundary.transform.position.x);
    }

    private bool Boundary_y() {
        return (transform.position.y - moveSpeed > bottomBoundary.transform.position.y)
            && (transform.position.y + moveSpeed < topBoundary.transform.position.y);
    }
    private float distance_x() {
        return Mathf.Abs(transform.position.x - player.transform.position.x);
    }
    private float distance_y() {
        return Mathf.Abs(transform.position.y - player.transform.position.y);
    }

    public void invert_start()//doorKnock使得世界反转的时候 向上移动镜头
    {
        transform.position = new Vector3(0, 216, -100);
    }
}
