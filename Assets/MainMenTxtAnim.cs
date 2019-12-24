using UnityEngine;
using System.Collections;

public class MainMenTxtAnim : MonoBehaviour {
	public GameObject Heart;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable() {
		MainMenuTxt Main = Heart.GetComponent<MainMenuTxt> ();
		Main.MainMenTxt ();
	
	}
}
