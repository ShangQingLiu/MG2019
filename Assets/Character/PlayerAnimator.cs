using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    public Animator playerAnimator;

    private bool _isTouched;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (Globals.worldState) {
            case Globals.state.NORMAL:
            case Globals.state.INVERT:
                playerAnimator.SetBool("isFloat", false);
                if (_isTouched)
                    playerAnimator.SetBool("isTouched", true);
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) {
                    playerAnimator.SetBool("isMove", true);
                }
                else {
                    playerAnimator.SetBool("isMove", false);
                    playerAnimator.SetBool("isTouched", false);
                }
                break;
            case Globals.state.ZEROGRAVITY:
                playerAnimator.SetBool("isMove", false);
                playerAnimator.SetBool("isFloat", true);
                if (_isTouched)
                    playerAnimator.SetBool("isTouched", true);
                else
                    playerAnimator.SetBool("isTouched", false);
                break;
        }
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Stone") {
            _isTouched = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.transform.tag == "Stone") {
            _isTouched = false;
        }
    }
}
