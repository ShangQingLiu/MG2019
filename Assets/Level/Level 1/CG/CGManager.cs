using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGManager : MonoBehaviour {

    public GameObject[] opening;
    public float showTime;

    private float _timer;
    private int _index;

    private void Awake() {
        Time.timeScale = 0;
    }
    // Use this for initialization
    void Start () {
        _timer = 0;
        _index = 0;
        opening[_index].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        _timer += Time.fixedDeltaTime;
        if(_timer > showTime) {
            _timer = 0;
            opening[_index].SetActive(false);
            if (_index == 2) {
                PlotManager.instance.SendMessage("CGOver");
                Destroy(this);
                return;
            }
            _index++;
            opening[_index].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Return))
            _timer += showTime;
	}
}
