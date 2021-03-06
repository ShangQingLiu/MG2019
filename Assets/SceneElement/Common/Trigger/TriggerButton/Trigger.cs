﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public GameObject door;

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.transform.tag == "Player" || collision.transform.tag == "Stone") {
            door.SendMessage("Open");
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.transform.tag == "Player" || collision.transform.tag == "Stone") {
            door.SendMessage("Open");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.transform.tag == "Player" || collision.transform.tag == "Stone") {
            door.SendMessage("Close");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.transform.tag == "Player" || collision.transform.tag == "Stone") {
            door.SendMessage("Close");
        }
    }

}
