using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullStone : MonoBehaviour
{
    public Rigidbody speStone;
    private Transform stone;
    private void Start()
    {
    }
    private void Update()
    {
        if (stone != null)
        {

            if (Input.GetKey(KeyCode.X))
            {
                Vector3 D = new Vector3(transform.position.x - stone.position.x,transform.position.y - stone.position.y,0.0f);
                float dist = D.magnitude;
                Vector3 pullDir = D.normalized;
                Debug.Log("D"+D);
                Debug.Log("dist"+dist);
                if (dist > 90) stone = null;
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
        if(collision.transform.name == "Stone 1")
        {
            stone = collision.transform; 
        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //   if(stone != null)
    //    {
    //        stone = null;
    //    } 
    //}



}
