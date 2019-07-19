using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MoveBtnCtrl : MonoBehaviour {

    private PlayableDirector _director;

    // Use this for initialization
    void Start () {
        _director = GetComponent<PlayableDirector>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (_director.state == PlayState.Playing)
                _director.Pause();
            else
                _director.Play();
        }
	}
}
