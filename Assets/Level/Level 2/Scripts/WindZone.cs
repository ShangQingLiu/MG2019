using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{

    private Rigidbody2D _body;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Globals.timeStop) {
            _body.velocity = new Vector2(0, 0);
            _body.gravityScale = 0;
            return;
        }

        if (Globals.worldState == Globals.state.NORMAL)
            _body.gravityScale = 5;
        else if (Globals.worldState == Globals.state.INVERT)
            _body.gravityScale = -5;
        else
            _body.gravityScale = 0;
    }
}
