using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FightBgDisable : MonoBehaviour {
	public Image Bg;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable() {
		Bg.enabled=false;
	}
}
