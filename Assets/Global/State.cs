using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Globals.worldState = Globals.state.NORMAL;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Globals.worldState = Globals.state.INVERT;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Globals.worldState = Globals.state.ZEROGRAVITY;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            Globals.timeStop = Globals.timeStop ? false : true;
        }
    }
}
