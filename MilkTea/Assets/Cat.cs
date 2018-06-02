using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //print("Start----------------");
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.down * 2 * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        print("OnTriggerEnter2D-----------");
    }
}
