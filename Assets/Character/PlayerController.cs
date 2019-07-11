using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody _body;
    private float _horiSpeed;
    private float _vertSpeed;
    private float _gravity;
    private bool _isGround;

    private enum PlayerState {
        MOVE,
        STOP
    }
    private PlayerState playerState;
    
	// Use this for initialization
	void Start () {
        _body = GetComponent<Rigidbody>();
        _gravity = Globals.gravity;
	}
	
	// Update is called once per frame
	void Update () {
        //超级简单操控人物移动
        _horiSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        if (Globals.worldState == Globals.state.ZEROGRAVITY)
            _vertSpeed = Input.GetAxis("Vertical") * moveSpeed;

        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                State_Normal();
                break;
            case Globals.state.INVERT:
                State_Invert();
                break;
            case Globals.state.ZEROGRAVITY:
                break;
        }

        switch (playerState) {
            case PlayerState.MOVE:
                break;
            case PlayerState.STOP:
                _horiSpeed = 0;
                break;
        }
        if (_isGround)
            _vertSpeed = 0;

        transform.Translate(_horiSpeed * Time.deltaTime, _vertSpeed * Time.deltaTime, 0);

	}

    private void State_Normal() {
        if (!_isGround)
            _vertSpeed -= _gravity;
        else
            _vertSpeed = 0;
    }

    private void State_Invert() {
        if (!_isGround)
            _vertSpeed += _gravity;
        else
            _vertSpeed = 0;
    }

    private void State_ZeroGravity() {

    }

    private void OnTriggerEnter(Collider other) {
        _vertSpeed = 0;
        _isGround = true;
    }

    private void OnTriggerStay(Collider other) {
        
    }

    private void OnTriggerExit(Collider other) {
        _isGround = false;
    }

    private void Rebound(Vector3 boundForce) {
        Debug.Log("Rebound");
        playerState = PlayerState.STOP;
    }
}
