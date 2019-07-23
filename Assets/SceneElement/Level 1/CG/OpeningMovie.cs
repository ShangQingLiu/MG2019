using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(AudioSource))]//必須要有AudioSource，任何加上此腳本的物件將自動加入AudioSource
public class OpeningMovie : MonoBehaviour
{

    public VideoPlayer movTexture;//影片
    private AudioSource AS_mov;//影片音軌

    void Start()
    {
        AS_mov = GetComponent<AudioSource>();
        movTexture.Play();
        AS_mov.Play();
    }


    void Update()
    {
        if (!movTexture.isPlaying)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("01_Main_Menu");//載入場景
        }
    }
}
