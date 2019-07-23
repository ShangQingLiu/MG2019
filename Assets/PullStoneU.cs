using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullStoneU : MonoBehaviour
{
    public Rigidbody speStone;
    private Transform _stone;
    private void Start()
    {
    }
    private void Update()
    {
        if (_stone != null)
        {

            if (Input.GetKey(KeyCode.X))
            {
                Vector3 D = new Vector3(transform.position.x - _stone.position.x,transform.position.y - _stone.position.y,0.0f);
                float dist = D.magnitude;
                Vector3 pullDir = D.normalized;
                Debug.Log("D"+D);
                Debug.Log("dist"+dist);
                if (dist > 90) _stone = null;
                else if (dist > 3)
                {
                    float pullF = 30;
                    float pullForDist = (dist - 3) / 2.0f;
                    if (pullForDist > 20)
                    {
                        pullForDist = 20;
                    }
                    pullF += pullForDist;
                    speStone.velocity += pullDir * (pullF * Time.deltaTime);
                }
                 
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name.Substring(0, 5));
        if(collision.transform.name.Substring(0,5) == "Stone")
        {
            _stone = collision.transform; 
        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //   if(_stone != null)
    //    {
    //        _stone = null;
    //    } 
    //}



}
