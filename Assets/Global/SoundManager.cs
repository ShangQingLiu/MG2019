using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    public AudioSource[] sounds;

    private void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        sounds[0].Play();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void BgmSet() {
        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                BgmSwitch(0);
                break;
            case Globals.state.INVERT:
                BgmSwitch(1);
                break;
            case Globals.state.ZEROGRAVITY:
                BgmSwitch(2);
                break;
        }
    }

    private void BgmSwitch(int soundNum) {
        for (int i = 0; i < sounds.Length; i++)
            if (i != soundNum)
                sounds[i].Stop();
        sounds[soundNum].Play();
    }
}
