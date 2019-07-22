using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SpKey : MonoBehaviour
{
    public GameObject door;
    private bool _isEnter;

    // Start is called before the first frame update
    void Start()
    {
        _isEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isEnter) {
            if (Input.GetKeyDown(KeyCode.Return))
                door.SendMessage("Open");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Player") {
            _isEnter = true;
        }
    }
}
