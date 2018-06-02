using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : MonoBehaviour {
    public Straw1 straw;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale = new Vector3(1f, straw.conTime, 1f);
	}
}
