using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuTxt : MonoBehaviour {
	public Text MainTxt;
	public Text x;
	public Text ItemTxt1;
	public Text ItemTxt2;
	public Text ItemTxt3;
	public Text ItemTxt4;
	public Text Act1;
	public Text Act2;
	public Text Page;
	public string Txt;
	public GameObject TextBox;
	public int Neutral = 0;
	public int Attack = 0;
	public int Mercy = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		//TextChange ();


	}

	public void MainMenTxt () {
		UITextTypeWriter Text = TextBox.GetComponent<UITextTypeWriter> ();
		Text.StopAllCoroutines ();
		Text.ChangeText (Txt,0f);
		MainTxt.enabled = true;
		x.enabled = true;
		ItemTxt1.enabled = false;
		ItemTxt2.enabled = false;
		ItemTxt3.enabled = false;
		ItemTxt4.enabled = false;
		Act1.enabled = false;
		Page.enabled = false;
	}
//	public void TextChange(){
//		if(Neutral == 0){
//			Txt = "Message 1 ";
//		}
//		if(Neutral == 1) {
//			Txt = "Message 2 ";
//		}
//		if(Neutral == 2){
//			Txt = "Message 3 ";
//		}
//	
//	
//	}
}
