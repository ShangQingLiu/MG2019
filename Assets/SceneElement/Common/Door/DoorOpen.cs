using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour {

    public AudioSource winnerSound;
    private bool _isEnter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_isEnter) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                if (GameManager.instance.isMissionAccomplished(SceneManager.GetActiveScene().buildIndex - 1)) {
                    //PlotManager.instance.SendMessage("GameOverPlot");
                    StartCoroutine("WaitToNextLevel");
                }
                    
                else
                    Debug.Log("Sorry, there's something hasn't be got!");
            }
        }
	}

    private IEnumerator WaitToNextLevel() {
        winnerSound.Play();
        yield return new WaitForSeconds(5);
        GameManager.instance.SendMessage("Reload");
        int nextIndex = SceneManager.GetActiveScene().buildIndex == 5 ? 0 : SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Player") {
            _isEnter = true;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
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
}
