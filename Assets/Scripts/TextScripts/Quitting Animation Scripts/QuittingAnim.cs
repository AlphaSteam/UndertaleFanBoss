using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuittingAnim : MonoBehaviour {
	
	public bool NoDot=false;
	public bool Dot1 = false;
	public bool Dot2 = false;
	public bool Dot3 = false;
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		Text Txt = gameObject.GetComponent<Text> ();
		if(NoDot){

			Txt.text = "Quitting";
		}
		else if(Dot1){
			Txt.text = "Quitting.";

		}
		else if(Dot2){
			Txt.text = "Quitting..";

		}
		else if(Dot3){

			Txt.text = "Quitting...";
		}

	}
}
