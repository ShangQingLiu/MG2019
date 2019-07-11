using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEyeMove : MonoBehaviour {

    public GameObject player;
    public float parameter;//坐标按比例缩小

    private float _offsetX;

	// Use this for initialization
	void Start () {
        _offsetX = transform.position.x;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
            player.transform.position.x * parameter,
            transform.position.y, transform.position.z);
	}
}
