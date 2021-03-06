﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour {

    public AudioSource timestopSound;
    public GameObject filter;

    private bool _isEnter;

    private void Update() {

        if (!_isEnter)
            return;

        if (Input.GetKeyDown(KeyCode.F)) {
            GameManager.instance.SendMessage("TimeStop");
            timestopSound.Play();
            filter.SetActive(Invert());
        }

    }

    private bool Invert() {
        return (filter.activeInHierarchy) ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            _isEnter = true;
        }
    }
    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Player") {
            _isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            _isEnter = false;
        }
    }
    
    private void OnTriggerExit(Collider collision) {
        if (collision.tag == "Player") {
            _isEnter = false;
        }
    }
}
