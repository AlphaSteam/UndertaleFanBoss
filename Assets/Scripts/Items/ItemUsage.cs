using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemUsage : MonoBehaviour {
	public Text Item1NU;
	public Text Item2NU;
	public Text Item3NU;
	public Text Item4NU;
	public Text Page;

	public bool IsItem1=false;
	public bool IsItem2=false;
	public bool IsItem3=false;
	public bool IsItem4=false;
	public bool IsItem5=false;
	public GameObject Heart;
	public GameObject ItemS;
	public bool AxisUsed = false;
	public GameObject Act;
	public Text x1;
	public Text x2;
	public Text Item1_1;
	public Text Item1_2;
	public Text Item2;
	public Text Item3;
	public Text Item4;
	public Button ItemButton;

	public Text MainTxt;

	public bool Item1Finished=false;
	public bool Item1_2Finished=false;
	public bool X1Finished=false;
	public bool X2Finished=false;
	public bool ItemTxtOn=false;

	public GameObject AtkDamage;






	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Axis () {
		
		Item Script = ItemS.GetComponent<Item> ();
		Act ActMov = Act.GetComponent<Act> ();


		if (Input.GetAxisRaw ("Submit") != 0) {
			if (AxisUsed == false) {
				
				AxisUsed = true;

			}
		} else {
				
				
		}
			


		if (Input.GetAxisRaw ("Submit") == 0 && Input.GetAxisRaw ("Cancel") == 0) {
			
			AxisUsed = false;
			if (Script.OnItemMenu || ActMov.OnActMenuNmb !=0 ) {
				Script.NOfClicks = 2;
			
			}
		}
	}
	public void ItemTextPress(){
		BattleFight BF = AtkDamage.GetComponent<BattleFight> (); 
		Item Script = ItemS.GetComponent<Item> ();

		if (Item1_2Finished) {
			if (Input.GetAxisRaw ("Submit") == 1) {
				if(ItemTxtOn){
					x1.enabled = false;
					x2.enabled = false;
					Item1_2.enabled = false;
					Item1_1.enabled = false;
					BF.enabled = true;
					BF.enabled = false;//Because it works with OnEnable.
					ItemTxtOn = false;
					Script.NOfClicks = 1;


				}
			
			}
		
		}
	
	
	}


	public void ItemText(){
		UITextTypeWriter x1Type = x1.GetComponent<UITextTypeWriter> ();
		UITextTypeWriterX2 x2Type = x2.GetComponent<UITextTypeWriterX2> ();
		UITextTypeWriterItem1 Item1_1Type = Item1_1.GetComponent<UITextTypeWriterItem1> ();
		UITextTypeWriterItem1_2 Item1_2Type = Item1_2.GetComponent<UITextTypeWriterItem1_2> ();


		if (Item1Finished) {
			x2Type.ChangeText ("*", 0f);
			x2.enabled = true;
			Item1Finished = false;
		}
		if (X2Finished) {
			Item1_2Type.ChangeText (Item1_2Type.Item1_2Txt, 0f);
			Item1_2.enabled = true;
			X2Finished = false;
		
		}
	
	}
		
	void Update(){
		ItemText ();
		ItemTextPress ();

		Axis ();
		Item Script = ItemS.GetComponent<Item> ();
		if (AxisUsed == true && Script.NOfClicks > 1) {
			{
			
				Submit (); 


			}
		
			}}

		
	public void ItemExit (){
		Item Script = ItemS.GetComponent<Item> ();
		Item1NU.enabled = false;
		Item2NU.enabled = false;
		Item3NU.enabled = false;
		Item4NU.enabled = false;
		Page.enabled = false;
		Script.OnItemMenu = false;
		Heart.SetActive (false);
		ItemButton.enabled = true;
		ItemButton.enabled = false;
		ItemButton.interactable = false;

	}	


		public void Submit(){
		Item Script = ItemS.GetComponent<Item> ();
		HeartMove Pos = Heart.GetComponent<HeartMove> ();
		PlayerHealth Health = Heart.GetComponent<PlayerHealth> ();
		UITextTypeWriter MainType = MainTxt.GetComponent<UITextTypeWriter> ();

		UITextTypeWriter x1Type = x1.GetComponent<UITextTypeWriter> ();
		UITextTypeWriterX2 x2Type = x2.GetComponent<UITextTypeWriterX2> ();
		UITextTypeWriterItem1 Item1_1Type = Item1_1.GetComponent<UITextTypeWriterItem1> ();
		UITextTypeWriter Item1_2Type = Item1_2.GetComponent<UITextTypeWriter> ();



		if (AxisUsed == true) {
			MainType.StopAllCoroutines ();

			if (Pos.HeartPos == 1 && Script.Item1Pos == 1 || Pos.HeartPos == 2 && Script.Item1Pos == 2 || Pos.HeartPos == 3 && Script.Item1Pos == 3 || Pos.HeartPos == 4 && Script.Item1Pos == 4 ) {
				if (Script.NOfClicks > 1) {
					if (Input.GetAxisRaw ("Submit") != 0) {
						MainType.StopAllCoroutines ();
						IsItem1 = true;
						Health.PHealth += 10;
						Script.Item1Pos = 0;
						x1.enabled = true;
						Item1_1Type.ChangeText (Item1_1Type.Item1Txt ,0f);
						Item1_1.enabled = true;
						ItemTxtOn = true;
						ItemExit ();
						

					}
				}
			}
		
		
			if (Pos.HeartPos == 2 && Script.Item2Pos == 2 || Pos.HeartPos == 1 && Script.Item2Pos == 1 || Pos.HeartPos == 3 && Script.Item2Pos == 3 || Pos.HeartPos == 4 && Script.Item2Pos == 4) {
				if (Script.NOfClicks > 1) {
					if (Input.GetAxisRaw ("Submit") != 0) {
						MainType.StopAllCoroutines ();
						IsItem2 = true;
						Health.PHealth += 10;
						Script.Item2Pos = 0;
						//At Least for now, they all have the same descriptions(Applies for all the other items right now)
						x1.enabled = true;
						Item1_1Type.ChangeText (Item1_1Type.Item1Txt ,0f);
						Item1_1.enabled = true;
						ItemTxtOn = true;
						ItemExit ();

					}
				}
			}
			if (Pos.HeartPos == 3 && Script.Item3Pos == 3 || Pos.HeartPos == 1 && Script.Item3Pos == 1 || Pos.HeartPos == 2 && Script.Item3Pos == 2 || Pos.HeartPos == 4 && Script.Item3Pos == 4) {
				if (Script.NOfClicks > 1) {
					if (Input.GetAxisRaw ("Submit") != 0) {
						MainType.StopAllCoroutines ();
						IsItem3 = true;
						Health.PHealth += 10;
						Script.Item3Pos = 0;
						//At Least for now, they all have the same descriptions(Applies for all the other items right now)
						x1.enabled = true;
						Item1_1Type.ChangeText (Item1_1Type.Item1Txt ,0f);
						Item1_1.enabled = true;
						ItemTxtOn = true;
						ItemExit ();

					}
				}
			}
	
			if (Pos.HeartPos == 4 && Script.Item4Pos == 4 || Pos.HeartPos == 1 && Script.Item4Pos == 1 || Pos.HeartPos == 2 && Script.Item4Pos == 2 || Pos.HeartPos == 3 && Script.Item4Pos == 3) {
				if (Script.NOfClicks > 1) {
					if (Input.GetAxisRaw ("Submit") != 0) {
						MainType.StopAllCoroutines ();
						IsItem4 = true;
						Health.PHealth += 10;
						Script.Item4Pos = 0;
						//At Least for now, they all have the same descriptions(Applies for all the other items right now)
						x1.enabled = true;
						Item1_1Type.ChangeText (Item1_1Type.Item1Txt ,0f);
						Item1_1.enabled = true;
						ItemTxtOn = true;
						ItemExit ();

					}
				}
			}
		}
	
	}
			}
		

		

	

