﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneState : MonoBehaviour
{
    private Rigidbody2D _body;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.timeStop) {
            _body.velocity = new Vector2(0, 0);
            _body.gravityScale = 0;
            return;
        }

        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                _body.gravityScale = Globals.gravity2D;
                break;
            case Globals.state.INVERT:
                _body.gravityScale = -Globals.gravity2D;
                break;
            case Globals.state.ZEROGRAVITY:
                _body.gravityScale = 0;
                break;
        }
    }
}
