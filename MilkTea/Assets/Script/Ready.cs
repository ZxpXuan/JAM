using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour {
	[SerializeField]
	private GameObject Player1;
	[SerializeField]
	private GameObject Player2;
	// Use this for initialization
	void Start () {
		Player1.SetActive (false);
		Player2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
