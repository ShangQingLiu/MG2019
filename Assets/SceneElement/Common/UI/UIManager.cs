using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject dlg_setting;
    public GameObject dlg_selectDlg;
    public GameObject dlg_option;
    public GameObject dlg_volume;
    public GameObject dlg_instruction;
    public GameObject dlg_prop;
    public GameObject[] Keys;

    public AudioSource buttonSound;

    private void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            buttonSound.Play();
            if (!dlg_setting.activeInHierarchy)
                dlg_setting.SetActive(true);
            else
                Close();
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            buttonSound.Play();
            if (!dlg_setting.activeInHierarchy) {
                dlg_setting.SetActive(true);
                dlg_selectDlg.SetActive(false);
                dlg_prop.SetActive(true);
            }
            else
                Close();
        }

	}

    public void ContinueGame() {
        dlg_setting.SetActive(false);
        buttonSound.Play();
    }

    public void Option() {
        dlg_selectDlg.SetActive(false);
        dlg_option.SetActive(true);
        buttonSound.Play();
    }

    public void Volume() {
        dlg_option.SetActive(false);
        dlg_volume.SetActive(true);
        buttonSound.Play();
    }
    
    public void Instruction() {
        dlg_option.SetActive(false);
        dlg_instruction.SetActive(true);
        buttonSound.Play();
    }

    public void Prop() {
        dlg_option.SetActive(false);
        dlg_prop.SetActive(true);
        buttonSound.Play();
    }

    public void OK() {
        dlg_prop.SetActive(false);
        dlg_volume.SetActive(false);
        dlg_instruction.SetActive(false);
        //当选项界面在激活状态时，退回到选择界面
        if (dlg_option.activeInHierarchy) {
            dlg_option.SetActive(false);
            dlg_selectDlg.SetActive(true);
        }
        else
            dlg_option.SetActive(true);
        buttonSound.Play();
    }

    public void ResetLevel() {
        buttonSound.Play();
        GameManager.instance.SendMessage("Reload");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame() {
        buttonSound.Play();
        GameManager.instance.SendMessage("Reload");
        SceneManager.LoadScene(0);
    }

    public void Close() {
        dlg_option.SetActive(false);
        dlg_volume.SetActive(false);
        dlg_instruction.SetActive(false);
        dlg_prop.SetActive(false);
        dlg_selectDlg.SetActive(true);
        dlg_setting.SetActive(false);
    }

    private void GetKey(int index) {
        Keys[index].SetActive(true);
    }
}
