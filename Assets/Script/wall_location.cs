using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_location : MonoBehaviour {
    float screenX;
    float screenY;
    // Use this for initialization
    void Start()
    {
        screenX = GameManager.screenX;
        screenY = GameManager.screenY;
        if(this.tag == "wall1")
        {
            transform.localScale = new Vector3(1f, 50f, 2f*screenX);
            transform.position = new Vector3(-screenY - 0.5f, -5f, 0f);
        }
        else if(this.tag == "wall2")
        {
            transform.localScale = new Vector3(1f, 50f, 2f * screenX);
            transform.position = new Vector3(screenY + 0.5f, -5f, 0f);
        }
        else if (this.tag == "wall3")
        {
            transform.localScale = new Vector3(2f*screenY, 50f, 1f);
            transform.position = new Vector3(0f, -5f, screenX + 0.5f);
        }
        else if (this.tag == "wall4")
        {
            transform.localScale = new Vector3(2f * screenY, 50f, 1f);
            transform.position = new Vector3(0f, -5f, -screenX -0.5f);
        }
        else if (this.tag == "ground")
        {
            transform.localScale = new Vector3(screenY / 5f, 1, screenX / 5f);
            transform.position = new Vector3(0f,0, 0f);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
