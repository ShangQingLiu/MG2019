using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour {

    public static PlotManager instance;
    public GameObject[] plots;
    public GameObject dialog;
    public GameObject subTip;

    public float plotTime;
    public float showTime;
    public GameObject plotPrefab;

    private float _timer;
    private int _curIndex;//当前对话文字序号
    private bool _isCGOver;
    private bool _isImportant;//重要的可进行强制打断的对话

    private void Awake() {
        instance = this;
        Time.timeScale = 0;
    }

    // Use this for initialization
    void Start () {
        _curIndex = 0;
        dialog.SetActive(true);
        plots[_curIndex].SetActive(true);
        _isCGOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        /**
         * plot序号：
         * 0-1：进场时的猫灵对话
         * 2-4：新手介绍
         * 5-6：第一次推动石头和触碰到水流时触发的对话
         * 7-10：正常时间、逆世界、零重力、时间静止时的对话
         * 11-12：拿到风铃和镜子道具时的对话
         * 13：通关时的对话
         * 14-18：随机触发对话 
         */
        if (!_isCGOver)
            return;

        _timer += Time.fixedDeltaTime;
        //线性播放前五段对话
        if (_curIndex <= 4) {
            if (_timer > plotTime) {
                _timer = 0;
                Debug.Log(_curIndex);
                dialog.SetActive(false);
                subTip.SetActive(false);
                plots[_curIndex].SetActive(false);
                _curIndex++;

                switch (_curIndex) {
                    case 0:
                    case 1:
                        dialog.SetActive(true);
                        plots[_curIndex].SetActive(true);
                        break;
                    case 2:
                    case 3:
                    case 4:
                        subTip.SetActive(true);
                        plots[_curIndex].SetActive(true);
                        break;
                }
                if (_curIndex == 4)
                    Time.timeScale = 1;
            }
            //回车跳过
            if (Input.GetKeyDown(KeyCode.Return))
                _timer += plotTime;
        }
        //播放完之后，随机播放
        else {
            if (!_isImportant){
                _timer += Time.fixedDeltaTime;
                if (_timer > Random.Range(0.7f, 0.8f) * showTime)
                    Plotover();
                if (_timer > showTime) {
                    _timer = 0;
                    float random = Random.Range(14, 19);
                    Debug.Log(random);
                    PlotShow((int)random);
                }
            }
            else {
                _timer += Time.fixedDeltaTime;
                if(_timer > showTime) {
                    Plotover();
                    _timer = 0;
                    _isImportant = false;
                }
            }
        }
	}

    private void CGOver() {
        _isCGOver = true;
    }
    //关闭之前所有的plot，确保只显示一个plot
    private void Plotover() {
        dialog.SetActive(false);
        foreach (GameObject plot in plots)
            plot.SetActive(false);
    }

    private void StatePlot() {
        _timer = 0;
        Plotover();
        switch (Globals.worldState) {
            case Globals.state.NORMAL:
                PlotShow(7);
                break;
            case Globals.state.INVERT:
                PlotShow(8);
                break;
            case Globals.state.ZEROGRAVITY:
                PlotShow(9);
                break;
        }
        _isImportant = true;
    }

    private void TimeStopPlot() {
        _timer = 0;
        Plotover();
        PlotShow(10);
        _isImportant = true;
    }

    private void GetKey(int index) {
        _timer = 0;
        Plotover();
        if (index == 0)
            PlotShow(11);
        else if (index == 1)
            PlotShow(12);
        _isImportant = true;
    }

    private void GameOverPlot() {
        _timer = 0;
        Plotover();
        PlotShow(13);
        _isImportant = true;
    }

    private void PlotShow(int index) {
        dialog.SetActive(true);
        plots[index].SetActive(true);
    }
    //private void StatePlot() {
    //    switch (Globals.worldState) {
    //        case Globals.state.NORMAL:
    //            StartCoroutine("PlotShow", 7);
    //            break;
    //        case Globals.state.INVERT:
    //            StartCoroutine("PlotShow", 8);
    //            break;
    //        case Globals.state.ZEROGRAVITY:
    //            StartCoroutine("PlotShow", 9);
    //            break;
    //    }
    //}

    //private void MissionAccomplished() {
    //    StartCoroutine("PlotShow",13);
    //}

    //private IEnumerator PlotShow(int index) {
    //    GameObject dlgShow = Instantiate(plotPrefab);
    //    dlgShow.GetComponentInChildren<SpriteRenderer>().sprite =
    //        plots[index].GetComponent<SpriteRenderer>().sprite;
    //    dlgShow.transform.position = dialog.transform.position;

    //    yield return new WaitForSeconds(3);
    //    Destroy(dlgShow);
    //}


}
