using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {

    public float scaleSpeed;
    public AudioSource doorSound;

    private float _maxLength;
    
    /*
     * Open:进入打开状态，门缩短
     * Clos:关闭状态，门伸长
     * Stop:停止，完全打开或完全关闭或时间静止时停止
     */
    private enum ScaleState {
        Open,
        Close,
        Stop
    }
    private ScaleState state;

	// Use this for initialization
	void Start () {
        state = ScaleState.Stop;
        _maxLength = 20;

    }
	
	// Update is called once per frame
	void Update () {
        if (Globals.timeStop)
            return;

        switch (state) {
            case ScaleState.Open:
                transform.localScale -= new Vector3(0, 1.2f * scaleSpeed, 0);
                break;
            case ScaleState.Close:
                transform.localScale += new Vector3(0, 0.8f * scaleSpeed, 0);
                break;
            case ScaleState.Stop:
                break;
        }
        
        if (transform.localScale.y < 0) {
            transform.localScale += new Vector3(0, 1.2f * scaleSpeed, 0);
            state = ScaleState.Stop;
            Debug.Log("Stop");
        }
        else if (transform.localScale.y > _maxLength) {
            transform.localScale -= new Vector3(0, 0.8f * scaleSpeed, 0);
            state = ScaleState.Stop;
            Debug.Log("Stop");
        }
	}

    private void Open() {
        state = ScaleState.Open;
    }

    private void Close() {
        state = ScaleState.Close;
    }
}
