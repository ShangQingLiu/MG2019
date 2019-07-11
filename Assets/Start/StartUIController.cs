using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour {

    public GameObject dlg_selectLevel;
    public GameObject dlg_setting;
    public GameObject dlg_selectSetting;
    public GameObject dlg_music;
    public GameObject dlg_description;

    public AudioSource btnSound;

	public void StartGame() {
        dlg_selectLevel.SetActive(true);
        btnSound.Play();
    }

    public void EndGame() {
        Application.Quit();
    }

    public void Setting() {
        dlg_setting.SetActive(true);
        btnSound.Play();
    }

    public void Music() {
        dlg_selectSetting.SetActive(false);
        dlg_music.SetActive(true);
        btnSound.Play();
    }

    public void Description() {
        dlg_selectSetting.SetActive(false);
        dlg_description.SetActive(true);
        btnSound.Play();
    }

    public void OK() {
        dlg_music.SetActive(false);
        dlg_description.SetActive(false);
        dlg_selectSetting.SetActive(true);
        btnSound.Play();
    }

    public void Close() {
        OK();
        dlg_setting.SetActive(false);
        dlg_selectLevel.SetActive(false);
        btnSound.Play();
    }

    public void SelectLevel(int level) {
        SceneManager.LoadSceneAsync(level);
        btnSound.Play();
    }
}
