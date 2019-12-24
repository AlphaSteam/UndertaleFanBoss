using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {
	public GameObject Heart;
	public GameObject ItemPos1;
	public GameObject ItemPos2;
	public GameObject ItemPos3;
	public GameObject ItemPos4;
	public bool OnItemMenu = false;
	public Text TextBox;
	public Text Item1;
	public Text Item2;
	public Text Item3;
	public Text Item4;
	public Text x;
	public GameObject ItemUsage;
	public Text Page;
	public Button ItemButton;
	public GameObject TextBoxCode;
	public AudioSource SelectFX;
	public GameObject ItemPos1Temp;
	public GameObject ItemPos2Temp;
	public GameObject ItemPos3Temp;
	public GameObject ItemPos4Temp;
	public int Item1Pos = 1;
	public int Item2Pos = 2;
	public int Item3Pos = 3;
	public int Item4Pos = 4;
	public int NOfClicks = 0;
	public Attacks Atk;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MovePos(){
		if (Input.GetAxisRaw ("Cancel") == 0) {
			ItemUsage Item = ItemUsage.GetComponent<ItemUsage> ();



			if (Item.IsItem1 && Item.IsItem2 && Item.IsItem3 && Item.IsItem4) {
		
			} 
			else {
				OnItemMenu = true;
				Heart.transform.position = ItemPos1.transform.position;


			}
		}



}
	public void WhenClicked(){
		Atk.CancelSpawn = false;
		if(Input.GetAxisRaw ("Cancel") == 0){
		ItemUsage Item = ItemUsage.GetComponent<ItemUsage> ();
			UITextTypeWriter Text = TextBox.GetComponent<UITextTypeWriter> ();
		HeartMove HeartP = Heart.GetComponent<HeartMove> ();
		if (Item.IsItem1 && Item.IsItem2 && Item.IsItem3 && Item.IsItem4) {
			SelectFX.Play ();
				Text.StopAllCoroutines ();
		} 
		else {
				if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Vertical") == -1 ){
					HeartP.KeyPressed = true;


				}

				
			TextBox.enabled = false;
				x.enabled=false;
			Page.enabled = true;
			ItemButton.enabled = false;
			ItemButton.interactable = false;
			UITextTypeWriter UI = TextBoxCode.GetComponent<UITextTypeWriter> ();
			UI.StopAllCoroutines ();
			SelectFX.Play ();
			HeartP.HeartPos = 1;
			NOfClicks = 1;

		}

			if (Item.IsItem1 && Item.IsItem2 && Item.IsItem3 && Item.IsItem4) {
		
		
			} else if (Item.IsItem1 && Item.IsItem2 && Item.IsItem3) {
				Item4.enabled = true;
				Item4.transform.position = ItemPos1Temp.transform.position;
				Item4Pos = 1;

			} else if (Item.IsItem4 && Item.IsItem2 && Item.IsItem3) {
				Item1.enabled = true;
				Item1Pos = 1;
			} else if (Item.IsItem1 && Item.IsItem3 && Item.IsItem4) {
				Item2.enabled = true;
				Item2.transform.position = ItemPos1Temp.transform.position;
				Item2Pos = 1;
			} else if (Item.IsItem1 && Item.IsItem2 && Item.IsItem4) {
				Item3.enabled = true;
				Item3.transform.position = ItemPos1Temp.transform.position;
				Item3Pos = 1;
			} else if (Item.IsItem1 && Item.IsItem2) {
				Item4.enabled = true;
				Item3.enabled = true;
				Item4.transform.position = ItemPos1Temp.transform.position;
				Item4Pos = 1;
		
			} else if (Item.IsItem3 && Item.IsItem4) {

				Item1.enabled = true;
				Item2.enabled = true;
				Item2.transform.position = ItemPos3Temp.transform.position;
				Item2Pos = 3;
			} else if (Item.IsItem1 && Item.IsItem4) {

				Item2.enabled = true;
				Item3.enabled = true;
				Item2.transform.position = ItemPos1Temp.transform.position;
				Item2Pos = 1;
			} else if (Item.IsItem3 && Item.IsItem1) {

				Item4.enabled = true;
				Item2.enabled = true;
				Item4.transform.position = ItemPos3Temp.transform.position;
				Item2.transform.position = ItemPos1Temp.transform.position;
				Item4Pos = 3;
				Item2Pos = 1;
			} else {

				if (Item.IsItem1 == false) {
					Item1.enabled = true;


				} else {  
					Item4.transform.position = ItemPos1Temp.transform.position;
			
					Item4Pos = 1;
					Item1Pos = 0;

				}
				if (Item.IsItem2 == false) {
					Item2.enabled = true;

				} else {
					Item4.transform.position = ItemPos2Temp.transform.position;

					Item4Pos = 2;
					Item2Pos = 0;

				}

				if (Item.IsItem3 == false) {
					Item3.enabled = true;
				} else {
					Item4.transform.position = ItemPos3Temp.transform.position;
					Item4Pos = 3;
					Item3Pos = 0;

				}

				if (Item.IsItem4 == false) {
					Item4.enabled = true;

				} else {
					Item4Pos = 0;

				}
			}
		}




	}
}
