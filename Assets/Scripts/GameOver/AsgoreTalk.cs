using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsgoreTalk : MonoBehaviour {
	//On Over GameObject
	public Text Asgore;
	public Text Name;
	public Text Asgore2;
	public Text Wait;
	public int AsgoreTxt=0;
	public int NOClicks;
	// Use this for initialization
	void OnEnable () {
		Asgore.enabled = true;
		AsgoreTxt = 1;
		UITextTypeWriter UI = Asgore.GetComponent<UITextTypeWriter> ();
		UI.ChangeText ("You cannot give up just yet...",0f);
	}
	
	// Update is called once per frame
	void Update () {
		Clicks ();
		UITextTypeWriter UI = Asgore.GetComponent<UITextTypeWriter> ();
		UITextTypeWriter UIName = Name.GetComponent<UITextTypeWriter> ();
		UITextTypeWriter UI2 = Asgore2.GetComponent<UITextTypeWriter> ();
		UITextTypeWriter UIW = Wait.GetComponent<UITextTypeWriter> ();

		if(UIName.Finished){
			UIW.ChangeText ("",0.8f);
			if(UIW.Finished){
			Asgore2.enabled = true;
			UI2.ChangeText ("Stay determined...",0f);
			UIName.Finished = false;
				UIW.Finished = false;

			}}
		if(UI2.Finished){
			AsgoreTxt = 3;
			UI2.Finished = false;

		}


		if(Input.GetAxisRaw("Submit") == 1){
			if(AsgoreTxt == 1){
				if(NOClicks>1){
					if(UI.Finished){
					NOClicks = 1;
					Name.enabled = true;
					Asgore.enabled = false;
					UIName.ChangeText ("Frisk!",0f);
						AsgoreTxt = 2;
					}
				}
			} 
			if(AsgoreTxt == 3){
				if (NOClicks > 1) {
					NOClicks = 1;
					//UI.StopAllCoroutines ();
					Asgore.enabled = false;
					Asgore2.enabled = false;
					Name.enabled = false;
					Wait.enabled = false;
					AsgoreTxt = 4;

				}
			}
				if(AsgoreTxt == 4){
					if (NOClicks > 1) {
						NOClicks = 1;
					AsgoreTxt = 0;
						SceneManager.LoadScene (0);
					}


				}



		}
	}
	public void Clicks(){
		if(Input.GetAxisRaw("Submit") == 0){
			NOClicks = 2;
		}
	
	
	}

}
