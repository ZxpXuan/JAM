using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {
	[SerializeField]
	private GameObject SettingPanel;
	[SerializeField]
	private GameObject MainPanel;
	// Use this for initialization
	void Start () {
		ShowMainMenu ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnStarBtnDown(){
		Debug.Log("Click start");
		Application.LoadLevel (1);
	}
	public void OnEndBtnDown(){
		Application.Quit ();
		Debug.Log("Click end");
	}
	private void ShowMainMenu(){
		MainPanel.SetActive (true);
	}

}
