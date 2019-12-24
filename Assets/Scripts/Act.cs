using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Act : MonoBehaviour {
	public GameObject ActPos1;
	public GameObject ActPos2;
	public GameObject ActPos3;
	public GameObject ActPos4;

	public Text TextBox;
	public Text x;
	public Text Check;
	public Text XCheck;
	public Text Dance;
	public Text Suspense;
	public Text XDance;
	public Text Dance_Text;
	public Text Dance_Text_2;
	public Text XDance_Text;
	public Text XDance_Text_2;

	public Button ActButton;
	public GameObject Heart;
	public AudioSource SelectFX;
	public GameObject TextBoxCode;
	public Text ActText1;
	public int OnActMenuNmb = 0;
	public GameObject ItemU;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		

	}
	public void MovePosAct(){
		Item Script = ItemU.GetComponent<Item> ();
		Heart.transform.position = ActPos1.transform.position;

		Script.NOfClicks = 1;
	}
	public void WhenClicked(){
		TextBox.enabled = false;
		x.enabled = false;
		ActText1.enabled = true;
		ActButton.enabled = false;
		ActButton.interactable = false;
		UITextTypeWriter UI = TextBoxCode.GetComponent<UITextTypeWriter> ();
		UI.StopAllCoroutines ();
		SelectFX.Play ();
		OnActMenuNmb = 1;

	
	
	}
}
