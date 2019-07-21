using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {

    public GameObject nozzle;
    public GameObject waterfall;
    public GameObject zeroWater;

    public AudioSource waterSound;

	// Use this for initialization
	void Start () {
        waterSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Globals.timeStop)
            return;

        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                waterfall.SetActive(true);
                zeroWater.SetActive(false);
                nozzle.transform.localEulerAngles = new Vector3(0, 0, 0);
                waterSound.volume = 0.2f;
                break;
            case Globals.state.INVERT:
                waterfall.SetActive(true);
                zeroWater.SetActive(false);
                nozzle.transform.localEulerAngles = new Vector3(180, 0, 0);
                waterSound.volume = 0.2f;
                break;
            case Globals.state.ZEROGRAVITY:
                waterfall.SetActive(false);
                zeroWater.SetActive(true);
                waterSound.volume = 0;
                break;
        }
	}
}
