using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDoor : MonoBehaviour
{
    public float scaleSpeed;
    private bool _isEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_isEnter) {
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
