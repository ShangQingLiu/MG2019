using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour {

    private bool _isEnter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_isEnter) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                if (GameManager.instance.isMissionAccomplished(1)) {
                    PlotManager.instance.SendMessage("GameOverPlot");
                    StartCoroutine("WaitToNextLevel");
                }
                    
                else
                    Debug.Log("Sorry, there's something hasn't be got!");
            }
        }
	}

    private IEnumerator WaitToNextLevel() {
        yield return new WaitForSeconds(5);
        GameManager.instance.SendMessage("Reload");
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            _isEnter = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            _isEnter = false;
        }
    }
}
