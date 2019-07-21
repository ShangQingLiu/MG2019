using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {

    public static Globals instance;
    public enum state {
        NORMAL,
        INVERT,
        ZEROGRAVITY
    }
    public static state worldState = state.NORMAL;
    public static float gravity = 50;
    public static float gravity2D = 50;
    public static bool timeStop = false;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        
	}
}
