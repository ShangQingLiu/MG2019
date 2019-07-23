using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor2D : MonoBehaviour
{
    public float scaleSpeed;
    public Globals.state doorState;//开门需要的状态

    private bool _isEnter;
    // Start is called before the first frame update
    void Start()
    {
        _isEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.timeStop)
            return;

        if(_isEnter && Globals.worldState == doorState) {
            if (transform.localScale.y > 0)
                transform.localScale -= new Vector3(0, 1.3f * scaleSpeed, 0);
        }
        else {
            if (transform.localScale.y < 1)
                transform.localScale += new Vector3(0, 0.7f * scaleSpeed, 0);
        }

        //越界反补
        if (transform.localScale.y < 0) {
            transform.localScale += new Vector3(0, 1.3f * scaleSpeed, 0);
        }
        else if (transform.localScale.y > 1) {
            transform.localScale -= new Vector3(0, 0.7f * scaleSpeed, 0);
        }
    }

    private void Open() {
        _isEnter = true;
    }

    private void Close() {
        _isEnter = false;
    }
}
