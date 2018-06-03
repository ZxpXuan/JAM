using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainUI : MonoBehaviour {
    public Canvas Esc;
    public Canvas death;
	// Use this for initialization
	void Start () {
        Esc.enabled = false;
        //death.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc.enabled = true;
            Time.timeScale = 0;
        }
	}
	public void OnStarBtnDown(){
		Debug.Log("Click start");
		Application.LoadLevel (1);
	}
	public void OnEndBtnDown(){
		Application.Quit ();
		Debug.Log("Click end");
	}
    public void Nopress() {
        Esc.enabled = false;
        Time.timeScale = 1;
    }

}
