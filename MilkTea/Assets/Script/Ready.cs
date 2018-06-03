using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour {
	[SerializeField]
	private GameObject Player1;
	[SerializeField]
	private GameObject Player2;
    int a = 0;
    int b = 0;
	// Use this for initialization
	void Start () {
		Player1.SetActive (false);
		Player2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J)) {
            Player1.SetActive(true);
            a = 1;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Player1.SetActive(true);
            b = 1;
        }
        if (a == 1 && b == 1) {
            Application.LoadLevel(1);
        }
    }
}
