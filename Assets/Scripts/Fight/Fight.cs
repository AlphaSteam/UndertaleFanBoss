using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fight : MonoBehaviour {
	public GameObject Heart;
	public GameObject ItemU;
	public GameObject ActU;
	public GameObject ActPos1;
	public Text TextBox;
	public Text x;
	public Text xFight;
	public GameObject TextBoxCode;
	public Text FightName;
	public Button FightButton;
	public AudioSource SelectFX;
	public bool OnFightMenu = false;
	public Image HealthBar;
	public Image HealthBarDamaged;
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

		TextBox.enabled = false;
		x.enabled = false;
		xFight.enabled = true;
		FightName.enabled = true;
		FightButton.enabled = false;
		FightButton.interactable = false;
		UITextTypeWriter UI = TextBoxCode.GetComponent<UITextTypeWriter> ();
		UI.StopAllCoroutines ();
		SelectFX.Play ();
		OnFightMenu = true;
		HealthBar.enabled = true;
		HealthBarDamaged.enabled = true;
	
	}

}
