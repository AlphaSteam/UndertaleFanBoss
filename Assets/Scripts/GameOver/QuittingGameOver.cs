using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuittingGameOver : MonoBehaviour {
	public Text QuittingTxt;
	public float Tme;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Quitting ();
	}
	public void Quitting(){

		if (Input.GetAxisRaw("Esc") == 1) {
			QuittingTxt.enabled = true;
			Tme += Time.deltaTime;
			if(Tme>1.5f){
				Application.Quit ();
			}
		}

		if (Input.GetAxis("Esc")==0) {
			QuittingTxt.enabled = false;
			Tme = 0;
		}

	}
}
