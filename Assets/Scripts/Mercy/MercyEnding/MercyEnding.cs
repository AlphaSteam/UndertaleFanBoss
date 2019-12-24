using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MercyEnding : MonoBehaviour {
	public Text MercyEndTxt;
	public int NOClicks;
	public int TxtNmb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Clicks ();
		UITextTypeWriter UI = MercyEndTxt.GetComponent<UITextTypeWriter> ();
		if (Input.GetAxisRaw ("Submit") == 1) {
			if (NOClicks > 1) {
				if(UI.Finished){
				if (TxtNmb == 0){
					TxtNmb = 1;
					NOClicks = 1;
				UI.StopAllCoroutines ();
				UI.ChangeText ("You danced and bringed peace to the hole world.", 0.05f);
						UI.Finished = false;
			}
				else if(TxtNmb==1){
					TxtNmb = 2;
					NOClicks = 1;
					UI.StopAllCoroutines ();
					UI.ChangeText ("THE END.", 0.05f);

				}
				}}
		}
	}
		public void Clicks(){
			if(Input.GetAxisRaw("Submit") == 0){
				NOClicks = 2;
			}
	}

	}