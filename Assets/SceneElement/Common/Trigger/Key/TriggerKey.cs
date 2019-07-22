using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKey : MonoBehaviour {

    public GameObject key;
    public AudioSource keySound;
    public int keyNum;//钥匙序列号

    private bool _isGet;
    private bool _isEnter;

    private void Update() {
        if (_isEnter) {
            if(Input.GetKeyDown(KeyCode.Return)) {
                StartCoroutine("KeyShow");
                _isEnter = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (!_isGet)
                _isEnter = true;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            if (!_isGet)
                _isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            _isEnter = false;
        }

    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            _isEnter = false;
        }
    }

    private IEnumerator KeyShow() { 
        Debug.Log("KeyShow");
        _isGet = true;
        key.SetActive(true);
        GameManager.instance.SendMessage("GetKey", keyNum);
        //PlotManager.instance.SendMessage("GetKey", keyNum);
        keySound.Play();

        //钥匙动画...

        //3s后消失
        yield return new WaitForSeconds(3);
        key.SetActive(false);
    }
}
