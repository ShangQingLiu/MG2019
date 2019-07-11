using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public enum state{
        NORMAL,
        TIMESTOP,
        INVERT,
        ZEROGRAVITY
    }
    public state timestop = state.TIMESTOP;
    public state normal = state.NORMAL;
    public state invert = state.INVERT;
    public state zerogravity = state.ZEROGRAVITY;

    //public static state worldState = state.NORMAL;

}
