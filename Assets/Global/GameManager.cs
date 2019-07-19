using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject[] stones;
    public GameObject door;
    public GameObject[] triggerDoor;
    public GameObject[] key;

    private bool[] _isKeyGot;

    private void Awake() {
        instance = this;
        _isKeyGot = new bool[6];
        for (int i = 0; i < _isKeyGot.Length; i++)
            _isKeyGot[i] = false;
    }

    private void TimeStop() {
        if (!Globals.timeStop) {
            Debug.Log("TimeStop");
            //停止
            //door.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            foreach (GameObject stone in stones)
                stone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Physics.gravity = new Vector3(0, 0, 0);
            Globals.timeStop = true;
        }
        else {
            StateManager.instance.SendMessage("StateChange");
            Globals.timeStop = false;
        }

    }

    private void OpenDoor(int index) {
        triggerDoor[index].SendMessage("Open");
    }
    private void CloseDoor(int index) {
        triggerDoor[index].SendMessage("Close");
    }

    private void GetKey(int index) {
        _isKeyGot[index] = true;
        UIManager.instance.SendMessage("GetKey", index);
    }

    public bool isMissionAccomplished(int level) {
        switch (level) {
            case 1:
                return (_isKeyGot[0] && _isKeyGot[1]);
            case 2:
                return (_isKeyGot[2] && _isKeyGot[3]);
            case 3:
                return (_isKeyGot[4] && _isKeyGot[5]);
            default:
                return false;
        }
    }

    public void Reload() {
        Globals.worldState = Globals.state.NORMAL;
        Globals.timeStop = false;
        Globals.gravity = 50;
    }
}
