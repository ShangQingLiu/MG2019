using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour {

    public int index;//对应控制门的序号

    private int _touchNum;//接触到button的石头数量
    private bool _doOpen;
    private bool _doClose;

	// Use this for initialization
	void Start () {
        _touchNum = 0;
        _doOpen = false;
        _doClose = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (_doOpen) {
            if(index == 0) {
                if(Globals.worldState == Globals.state.INVERT) {
                    GameManager.instance.SendMessage("OpenDoor", index);
                    _doOpen = false;
                    _doClose = true;
                }
            }

            else if(index == 1) {
                if (Globals.worldState == Globals.state.NORMAL) {
                    GameManager.instance.SendMessage("OpenDoor", index);
                    _doOpen = false;
                    _doClose = true;
                }
            }
        }

        if (_doClose) {
            if (index == 0 && Globals.worldState != Globals.state.INVERT) {
                GameManager.instance.SendMessage("CloseDoor", index);
                _doClose = false;
                _doOpen = true;
            }
            else if (index == 1 && Globals.worldState != Globals.state.NORMAL) {
                GameManager.instance.SendMessage("CloseDoor", index);
                _doClose = false;
                _doOpen = true;
            }

        }

    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Stone") {
            Debug.Log("Button enter");
            //只在第一个石头碰上去时，设置为可开门
            if(_touchNum == 0)
                _doOpen = true;
            _touchNum++;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.transform.tag == "Stone") {
            _touchNum--;
            //最后的石头离开，一定会关门
            if (_touchNum == 0) {
                GameManager.instance.SendMessage("CloseDoor", index);
                _doOpen = false;
                _doClose = false;
            }
        }
    }
}
