using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindZone : MonoBehaviour
{
    private Rigidbody2D _body;
    //public GameObject _windZone;
    //public GameObject _windCat;
    //public GameObject _stone;

    //private bool _isStoneBlock = false;
    //private BoxCollider2D boxCol;
    //private BoxCollider2D stoneCol;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        
    }

    //private void Awake()
    //{
    //    boxCol = _windZone.GetComponent<BoxCollider2D>();
    //    stoneCol = _stone.GetComponent<BoxCollider2D>();
    //}
    // Update is called once per frame
    void Update() {
        if (Globals.timeStop) {
            _body.velocity = new Vector2(0, 0);
            _body.gravityScale = 0;
            return;
        }

        if (Globals.worldState == Globals.state.NORMAL)
            _body.gravityScale = 5;
        else if (Globals.worldState == Globals.state.INVERT)
            _body.gravityScale = -5;
        else
            _body.gravityScale = 0;

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    boxCol.offset = new Vector2(-(-(boxCol.Distance(stoneCol).distance) + boxCol.size.x+ stoneCol.size.x)/2, boxCol.offset.y);
    //    Debug.Log(boxCol.size.x+","+ stoneCol.size.x);
    //    boxCol.size = new Vector2(Mathf.Abs(boxCol.Distance(stoneCol).distance), boxCol.size.y);
    //    Debug.Log(Mathf.Abs(boxCol.Distance(stoneCol).distance) + "," + boxCol.size.y);
        
    //}
}
