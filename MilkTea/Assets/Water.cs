using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //print("Water-------------------");
        transform.localScale = new Vector3(1f,0.6f,1f);
        float offy = 1.5f * 0.4f / 2f;
        transform.localPosition = new Vector3(0f, -offy, 0f);

    }

    

	// Update is called once per frame
	void Update () {
		
	}
}
