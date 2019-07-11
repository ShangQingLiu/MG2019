using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public static StateManager instance;

    private float _gravity;

    private void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Start");
        _gravity = Globals.gravity;
	}

    private void StateChange() {
        Debug.Log("Change");
        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                Physics.gravity = new Vector3(0, -_gravity, 0);
                break;
            case Globals.state.INVERT:
                Physics.gravity = new Vector3(0, _gravity, 0);
                break;
            case Globals.state.ZEROGRAVITY:
                Physics.gravity = new Vector3(0, 0, 0);
                break;
        }
    }
}
