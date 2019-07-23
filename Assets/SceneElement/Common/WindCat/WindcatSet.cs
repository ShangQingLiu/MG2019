using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindcatSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if(collision.transform.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.Return)) {
                if (GetComponent<WindZone>() != null)
                    GetComponent<WindZone>().enabled = false;
                else
                    Debug.Log("No such script");
            }
        }
        
    }
}
