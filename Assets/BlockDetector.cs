using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetector : MonoBehaviour
{

    private bool _isBlock = false;
    public GameObject _windCat;
    private Collision2D _col;
    // Start is called before the first frame update

    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if (_isBlock)
        {
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("good");
        _isBlock = true;
        _col = collision;
            Debug.Log(_windCat.GetComponent<BoxCollider2D>().Distance(collision.collider));
    }
}
