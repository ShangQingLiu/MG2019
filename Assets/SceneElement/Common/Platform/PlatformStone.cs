using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStone : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.transform.tag == "Stone") {
            door.SendMessage("Open");
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.transform.tag == "Stone") {
            door.SendMessage("Open");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.transform.tag == "Stone") {
            door.SendMessage("Close");
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.transform.tag == "Stone") {
            door.SendMessage("Close");
        }
    }
}
