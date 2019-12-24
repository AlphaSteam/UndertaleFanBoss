using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mercy : MonoBehaviour {
	public GameObject Heart;
	public GameObject ItemU;
	public GameObject ActU;
	public GameObject ActPos1;
	public Text TextBox;
	public Text x;
	public GameObject TextBoxCode;
	public Text MercyTxt;
	public Button MercyButton;
	public AudioSource SelectFX;
	public bool OnMercyMenu = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void MovePos(){
		Item Script = ItemU.GetComponent<Item> ();


			Heart.transform.position = ActPos1.transform.position;
			Script.NOfClicks = 1;




	
	}

	public void WhenClicked(){
		MercyTxt.enabled = true;
		MercyButton.enabled = false;
		MercyButton.interactable = false;
		TextBox.enabled = false;
		x.enabled = false;
		UITextTypeWriter UI = TextBoxCode.GetComponent<UITextTypeWriter> ();
		UI.StopAllCoroutines ();
		SelectFX.Play ();
		OnMercyMenu = true;
	}
}
