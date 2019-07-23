using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchSceneTimer : MonoBehaviour
{
    public float _CGTime;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _CGTime)
        {
            SceneManager.LoadScene("Level 1"); 
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {

            SceneManager.LoadScene("Level 1"); 
        }

    }
}
