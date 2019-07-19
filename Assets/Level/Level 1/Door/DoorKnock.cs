using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnock : MonoBehaviour {

    public GameObject character;
    public GameObject[] catEyes;//猫眼素材
    public AudioSource switchSound;//切换音效
    public AudioSource miaoSound;//确定场景切换音效，喵叫
    public GameObject mainCamera;//主镜头
    public float knockTime;//敲门持续时间

    private bool _isEnter;//Player是否进入敲门范围
    private float _timer;
    private bool _isKnock;

    /*
     * 表示当前展现的猫眼所对应序号
     * 0:Normal 1:Invert 2:ZeroGravity
     */
    private int _curNum;
    /*
     * 记录当前worldState对应序号
     * 若玩家敲门时不修改状态，则在玩家离开时复原
     */
    private int _recordNum;

	// Use this for initialization
	void Start () {
        _isEnter = false;
        _curNum = 0;
        _timer = 0;
        _isKnock = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!_isEnter)
            return;

        if (Input.GetKeyDown(KeyCode.Q)) {
            CurLeft();
            SetCatEye();
            switchSound.Play();

            _isKnock = true;
            _timer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            CurRight();
            SetCatEye();
            switchSound.Play();

            _isKnock = true;
            _timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            EnsureChange();
        }
        if (_isKnock) {
            Debug.Log("Knock");
            _timer += Time.deltaTime;
            character.GetComponent<Animator>().SetBool("isKnocked", true);
            if (_timer > knockTime) {
                Debug.Log("Knock end");
                character.GetComponent<Animator>().SetBool("isKnocked", false);
                _timer = 0;
                _isKnock = false;
            }
        }

	}
    
    //游标_curNum左移
    private void CurLeft() {
        _curNum = (_curNum == 0) ? 2 : _curNum - 1;
    }

    private void CurRight() {
        _curNum = (_curNum == 2) ? 0 : _curNum + 1;
    }

    //设置眼睛
    private void SetCatEye() {
        foreach (GameObject eye in catEyes)
            eye.SetActive(false);
        catEyes[_curNum].SetActive(true);
    }

    private void EnsureChange() {
        switch (_curNum) {
            case 0:
                Globals.worldState = Globals.state.NORMAL;
                break;
            case 1:
                Globals.worldState = Globals.state.INVERT;
                mainCamera.SendMessage("invert_start");
                break;
            case 2:
                Globals.worldState = Globals.state.ZEROGRAVITY;
                break;
        }
        miaoSound.Play();
        Debug.Log(Globals.worldState);
        if (!Globals.timeStop) {
            StateManager.instance.SendMessage("StateChange");
            PlotManager.instance.SendMessage("StatePlot");
        }

        if (_recordNum != _curNum) {
            SoundManager.instance.SendMessage("BgmSet");
        }
        _recordNum = _curNum;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            _isEnter = true;
            _recordNum = _curNum;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            _isEnter = false;
            _curNum = _recordNum;
            SetCatEye();
        }
    }
}
