using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartMove : MonoBehaviour {
	//General(?
	public GameObject Pos1;
	public GameObject Pos2;
	public GameObject Pos3;
	public GameObject Pos4;
	public Button Act1;
	public Button Item1;
	public Button Mercy1;
	public Button Fight1;
	public AudioSource SelectFX;
	public AudioSource PressFx;
	public GameObject ItemUsage;
	public int HeartPos = 0;
	public bool AxisInUse = false;
	public GameObject ItemI;
	//Act
	public GameObject ActScript;
	public Text Name;
	public Text Desc;
	public Text xAct;
	public bool NameFinished = false;
	public bool DescFinished = false;
	public bool ReadingAct=false;
	public bool ReadingDance=false;
	public bool DanceFinished = false;
	public bool Dance2Finished = false;
	public string DanceTxt;
	public string DanceTxt2;
	public int DanceNmb=0;
	public bool SuspenseFinished = false;
	//General2(?
	public GameObject TextBox;//It has the TalkBox Script as a component
	public GameObject MercyMoveScript;
	public GameObject FightMoveScript;
	public Text MercyTxt;
	//Fight
	public Text xFight;
	public Text FightName;
	public Image HealthBar_Enemy;
	public GameObject HealthBar_Enemy_GameObject;
	public Image HealthBarDamaged_Enemy;
	public Image FightBg;
	public GameObject FightBar;
	public bool Attacking = false;
	//Talk
	public Text TalkBox;
	public bool TalkBoxFinished;
	//Movement
	public static Vector2 right = new Vector2 (1, 0);
	public static Vector2 left = new Vector2 (-1, 0);
	public static Vector2 up = new Vector2 (0,1);
	public static Vector2 upR = new Vector2 (1,1);
	public static Vector2 upL = new Vector2 (-1,1);
	public static Vector2 down = new Vector2 (0, -1);
	public static Vector2 downR = new Vector2 (1, -1);
	public static Vector2 downL = new Vector2 (-1, -1);
	public float speed = 50;
	public float MoveX = 0f;
	public float MoveY = 0f;
	//Other
	public GameObject Attack_0;
	public GameObject AtkDamage;
	//Key
	public bool KeyPressed=false;
	//Mercy
	public bool Spareable = false;
	public Color yellow = new Color();
	//Attacks
	public GameObject Attacks; 
	public Vector2 HeartPosition = new Vector2();
	public static Vector2 HeartPositionTransform;
	public int r;
	//FadeToBlackAnim
	public Animator FadeToBlackAnim;
	//Music
	public AudioSource Music;


	// Use this for initialization
	void Awake() {
		//DontDestroyOnLoad (transform.gameObject);
	}
	void Update()
	{  
		
		HeartPosition =(Vector2)gameObject.transform.position;
		if (gameObject.transform.position != null) {
		
			HeartPositionTransform = HeartPosition; 

		}

		ItemMove ();
		ActMove ();
		MercyMove ();
		FightMove ();
		TalkBoxSc ();
		ActText ();
		ActTxtPress ();
		DancingChange ();

	}
	void FixedUpdate(){
		BattleMove ();
	
	
	}



	public void BattleMove(){
		TalkBox Talk = TextBox.GetComponent<TalkBox> ();
		BattleExit BatExit = TextBox.GetComponent<BattleExit> ();
		Rigidbody2D Rb = gameObject.GetComponent<Rigidbody2D> ();
		if(BatExit.InBattle){
			if(Talk.Talking == false){
			MoveX = Input.GetAxisRaw ("Horizontal");
			MoveY = Input.GetAxisRaw ("Vertical");
			Rb.velocity = new Vector2 (MoveX * speed, MoveY * speed);
		
			}

			


//			 if (Input.GetAxisRaw ("Horizontal") == 0 && Input.GetAxisRaw ("Vertical") == 0) {
//				Rb.drag = 10000;
//			} 
//			else
//			{Rb.drag = 0f;
//			}
//			transform.position += move * speed * Time.deltaTime;(OLD MOVEMENT NOT TOO GOOD)

		}
		else{
			Rb.velocity = new Vector2 (0,0);

		}
	
	
	
	}

	public void TalkBoxSc (){
		GameObject item = GameObject.Find ("ItemMove");
		Item IScript = item.GetComponent<Item> ();
		TalkBox Talk = TextBox.GetComponent<TalkBox> ();
		UITextTypeWriterTalkBox TypeTalk = TalkBox.GetComponent<UITextTypeWriterTalkBox> ();
		BattleExit BatExit = TextBox.GetComponent<BattleExit> ();
		Attacks Attack = Attacks.GetComponent<Attacks> ();
		HealthBar_Enemy HBE = HealthBar_Enemy_GameObject.GetComponent<HealthBar_Enemy> ();

	
		if (Talk.Talking) {
			if (TalkBoxFinished) {
				//Talk.StopAllCoroutines ();
				Talk.StartCoroutine ("TalkProgress",4);
				if (Input.GetAxisRaw ("Submit") == 1) {
			if (IScript.NOfClicks > 1) {
						Talk.TalkingProgress = false;
						Talk.TalkBoxText.enabled = false;
						Talk.TalkBoxImage.enabled = false;
						TypeTalk.StopAllCoroutines ();
						BatExit.InBattle = true;
						if (HBE.Betrayed == false && HBE.Dead == false) {
							Talk.Talking = false;

							if (Attack.AttackNumber == 0) {//AtkNumber in Attack GameObject
								BatExit.StartCoroutine ("BattleDuration", 4);
								Attack.ChoseAttack ();
							} else if (Attack.AttackNumber == 1) {
								BatExit.StartCoroutine ("BattleDuration", 6);
								Attack.ChoseAttack ();
							} else if (Attack.AttackNumber == 2) {
								BatExit.StartCoroutine ("BattleDuration", 1000000);
								Attack.ChoseAttack ();
							}
						} 
						else {
							if (Spareable == false) {
								FadeToBlackAnim.Play ("FadeToBlack");
								SceneManager.LoadScene (3);
							}
						}
					}
				}
				if (Talk.TalkingProgress) {
					Talk.TalkingProgress = false;
					Talk.TalkBoxText.enabled = false;
					Talk.TalkBoxImage.enabled = false;
					TypeTalk.StopAllCoroutines ();
					BatExit.InBattle = true;
					if (HBE.Betrayed == false && HBE.Dead == false) {
						Talk.Talking = false;
						if (Attack.AttackNumber == 0) {//AtkNumber in Attack GameObject
							BatExit.StartCoroutine ("BattleDuration", 4);
						} else if (Attack.AttackNumber == 1) {
							BatExit.StartCoroutine ("BattleDuration", 6);
						} else if (Attack.AttackNumber == 2) {
							BatExit.StartCoroutine ("BattleDuration", 1000000);
						}
					} else {
						if (Spareable == false) {
							FadeToBlackAnim.Play ("FadeToBlack");
							SceneManager.LoadScene (3);
						}
					}
				}
			}
		}
//		if(Talk.Talking){
//			if(TalkBoxFinished){
//				Talk.StartCoroutine ("TalkProgress");
//				if()
//
//
//			}
//
//		}
	}

	public void FightMove(){
		Fight FightScript = FightMoveScript.GetComponent<Fight> ();
		Mercy MercyScript = MercyMoveScript.GetComponent<Mercy> ();
		FightBar FightB = FightBar.GetComponent<FightBar> ();
		SpriteRenderer spr = FightBar.GetComponent<SpriteRenderer> ();
		HitSound Hs = Attack_0.GetComponent<HitSound> ();
		BattleFight Bf = AtkDamage.GetComponent<BattleFight> ();
		GameObject item = GameObject.Find ("ItemMove");
		Item IScript = item.GetComponent<Item> ();
		GameObject act = GameObject.Find ("ActMove");
		Act Script = act.GetComponent<Act> ();

		Attacks Attack = Attacks.GetComponent<Attacks> ();

		Animator AtkDamageAnim = AtkDamage.GetComponent<Animator> ();
		Animator BgAnim = FightBg.GetComponent<Animator> ();

		if (Input.GetAxisRaw ("Cancel") == 1) {
			if (FightScript.OnFightMenu) {
				gameObject.transform.position = Fight1.transform.position;
				Fight1.enabled = true;
				Fight1.interactable = true;

				Fight1.Select ();
				MainMenuTxt Main = GetComponent<MainMenuTxt> ();
				Main.MainMenTxt ();
				FightScript.OnFightMenu = false;
				Script.OnActMenuNmb = 0;
				IScript.OnItemMenu = false;
				xFight.enabled = false;
				FightName.enabled = false;
				HealthBar_Enemy.enabled = false;
				HealthBarDamaged_Enemy.enabled = false;
			}
		}

		if (Input.GetAxisRaw ("Submit") == 1) {
			if (IScript.NOfClicks > 1) {
				if (FightScript.OnFightMenu) {
					Attack.CancelSpawn = false;
					xFight.enabled = false;
					FightName.enabled = false;
					HealthBar_Enemy.enabled = false;
					HealthBarDamaged_Enemy.enabled = false;
					PressFx.Play ();
					gameObject.SetActive (false);
					Fight1.enabled = true;
					Fight1.enabled = false;
					spr.enabled = true;
					Attacking = true;
					IScript.NOfClicks = 1;
					FightB.IsMoving = true;
					FightScript.OnFightMenu = false;
					Hs.enabled = false;
					Bf.enabled = false;
					BgAnim.enabled = true;
					FightBg.enabled = true;



				}
	
	
			}
		}
	}
	public void MercyMove (){
		Mercy MercyScript = MercyMoveScript.GetComponent<Mercy> ();
		GameObject item = GameObject.Find ("ItemMove");
		Item IScript = item.GetComponent<Item> ();
		GameObject act = GameObject.Find ("ActMove");
		Act Script = act.GetComponent<Act> ();
		BattleFight BF = AtkDamage.GetComponent<BattleFight> (); 
		Attacks Attack = Attacks.GetComponent<Attacks> ();

		if (Spareable) {
			MercyScript.MercyTxt.color = yellow;
		
		}


		if (MercyScript.OnMercyMenu) {


			if (Input.GetAxisRaw ("Cancel") == 1) {
				gameObject.transform.position = Mercy1.transform.position;
				Mercy1.enabled = true;
				Mercy1.interactable = true;
				MercyTxt.enabled = false;
				Mercy1.Select ();
				MainMenuTxt Main = GetComponent<MainMenuTxt> ();
				Main.MainMenTxt ();
				MercyScript.OnMercyMenu = false;
				Script.OnActMenuNmb = 0;
				IScript.OnItemMenu = false;
			}
		
			if(Input.GetAxisRaw("Submit") == 1){
				if (IScript.NOfClicks > 1) {
					if(Spareable == false){
						Attack.CancelSpawn = false;
						MercyScript.MercyTxt.enabled = false;
						Mercy1.enabled = true;
						Mercy1.enabled = false;
						Mercy1.interactable = false;
						MercyScript.OnMercyMenu = false;
						BF.enabled = true;
						BF.enabled = false;//Battle Fight works on Enable
						IScript.NOfClicks=1;
					}
					else if(Spareable){
						FadeToBlackAnim.Play ("FadeToBlack");

					}
				
				}


			}
		}
	
	
	}

	public void ActText(){
		UITextTypeWriterName Nam = Name.GetComponent<UITextTypeWriterName> ();
		UITextTypeWriterDesc Des = Desc.GetComponent<UITextTypeWriterDesc> ();
		UITextTypeWriter x = xAct.GetComponent<UITextTypeWriter> ();
		GameObject act = GameObject.Find ("ActMove");
		Item IScript = ItemI.GetComponent<Item> ();
		Act Script = act.GetComponent<Act> ();
		Animator TxtAnim = TextBox.GetComponent<Animator> ();
		BattleFight BF = AtkDamage.GetComponent<BattleFight> (); 

		if (Script.OnActMenuNmb == 0) {
			if (NameFinished) {
				xAct.enabled = true;
				x.ChangeText ("*", 0f);
				Des.ChangeText (Des.text, 0f);
				Desc.enabled = true;
				NameFinished = false;

			}
		}


	
	
	}
	public void ActTxtPress(){
		UITextTypeWriterName Nam = Name.GetComponent<UITextTypeWriterName> ();
		UITextTypeWriterDesc Des = Desc.GetComponent<UITextTypeWriterDesc> ();
		UITextTypeWriter x = xAct.GetComponent<UITextTypeWriter> ();
		GameObject act = GameObject.Find ("ActMove");
		Item IScript = ItemI.GetComponent<Item> ();
		Act Script = act.GetComponent<Act> ();
		Animator TxtAnim = TextBox.GetComponent<Animator> ();
		BattleFight BF = AtkDamage.GetComponent<BattleFight> (); 
		//TalkBox
		TalkBox TalkBox = TextBox.GetComponent<TalkBox>();

		if (ReadingAct) {
			if (DescFinished) {
				if (Input.GetAxisRaw ("Submit") == 1) {
					Desc.enabled = false;//Desc in check
					x.enabled = false;//* in Desc(?
					xAct.enabled = false;//* in Name(?
					Name.enabled = false;//Name in check
					DescFinished = false;//If not works forever
					IScript.NOfClicks = 1;
					BF.enabled = true;
					BF.enabled = false;//Because it works with OnEnable.
					ReadingAct = false;
					TalkBox.TalkBoxTextString = "Ayy lmao.";
				}
			}
			else {
				if(Input.GetAxisRaw ("Cancel") == 1){
					Nam.StopAllCoroutines ();
					Des.StopAllCoroutines ();
					Name.text = Nam.text;
					Desc.enabled = true;
					xAct.enabled = true;
					Desc.text = Des.text;
					DescFinished = true;


				}
			
			}



			}
		if(ReadingDance){
			if (Dance2Finished) {
				if (Input.GetAxisRaw ("Submit") == 1) {
					IScript.NOfClicks = 1;
					Script.Dance_Text.enabled = false;
					Script.Dance_Text_2.enabled = false;
					Script.XDance_Text.enabled = false;
					Script.XDance_Text_2.enabled = false;
					Script.Suspense.enabled = false;
					Dance2Finished = false;
					BF.enabled = true;
					BF.enabled = false;
					ReadingDance = false;
					DanceNmb += 1;
				
				}
			} 
			else {
				if (Input.GetAxisRaw ("Cancel") == 1) {
					UITextTypeWriterSuspense SusType = Script.Suspense.GetComponent<UITextTypeWriterSuspense> ();
					UITextTypeWriterDance2 Dance2Type = Script.Dance_Text_2.GetComponent<UITextTypeWriterDance2> ();
					UITextTypeWriterDance DanceType = Script.Dance_Text.GetComponent<UITextTypeWriterDance> ();
					DanceType.StopAllCoroutines();
					SusType.StopAllCoroutines ();
					Dance2Type.StopAllCoroutines ();
					IScript.NOfClicks = 1;
					Script.Dance_Text.enabled = true;
					Script.Dance_Text_2.enabled = true;
					Script.XDance_Text.enabled = true;
					Script.XDance_Text_2.enabled = true;
					Script.Suspense.enabled = true;
					Script.Dance_Text.text = DanceTxt;
					Script.Dance_Text_2.text = DanceTxt2;
					Script.Suspense.text="...";
					DanceNmb += 1;
					Script.XDance_Text.text = "*";
					Script.XDance_Text_2.text = "*";
					Dance2Finished = true;
				
				}
			
			
			}
			}
	
	
		
	}
	public void DancingChange(){
		GameObject act = GameObject.Find ("ActMove");
		Act Script = act.GetComponent<Act> ();
		UITextTypeWriterSuspense SusType = Script.Suspense.GetComponent<UITextTypeWriterSuspense> ();
		UITextTypeWriterDance2 Dance2Type = Script.Dance_Text_2.GetComponent<UITextTypeWriterDance2> ();
		//TalkBox
		TalkBox TalkBox = TextBox.GetComponent<TalkBox>();
		//TextBox
		MainMenuTxt MainMenTxt = gameObject.GetComponent<MainMenuTxt>();
		if(DanceFinished) {
			SusType.ChangeText ("...",0f);
			Script.Suspense.enabled = true;
			DanceFinished = false;

		}
		if (SuspenseFinished) {
			SuspenseFinished = false;
			Script.XDance_Text_2.enabled = true;
			Script.Dance_Text_2.enabled = true;
			Dance2Type.ChangeText (DanceTxt2, 0f);
		}
	
		//Variations of the message indicating how closer you are to sparing(The talkbox msgs are one below of the corresponding one)
		if (DanceNmb == 0) {
			DanceTxt="You try to dance like him";
			DanceTxt2 = "You do it wrong.";
		} 
		else if (DanceNmb == 1) {
			DanceTxt2 = "You do a little better.";
			TalkBox.TalkBoxTextString = "What was that?";
			MainMenTxt.Txt = "He doesn't like your dancing";
		} 
		else if (DanceNmb == 2) {
			DanceTxt2 = "You start to get the rythym.";
			TalkBox.TalkBoxTextString = "You think you can dance like me?";
			MainMenTxt.Txt = "He doesn't like your dancing2";
		} 
		else if (DanceNmb == 3) {
			DanceTxt2 = "You begin to understand the dance.";
			TalkBox.TalkBoxTextString = "Very catchy ah?";
		} 
		else if (DanceNmb == 4) {
			DanceTxt2 = "You get one step right.";
			TalkBox.TalkBoxTextString = "Watch and learn kiddo.";
		}
		else if (DanceNmb == 5) {
			DanceTxt2 = "You do almost as well as he.";
			TalkBox.TalkBoxTextString = "I like that.";
		}
		else if (DanceNmb == 6) {
			DanceTxt2 = "You start glowing.";
			TalkBox.TalkBoxTextString = "Quiero decirte al oido, tantas cosas preciosas...(♫)";
		}
		else if (DanceNmb == 7) {
			DanceTxt2 = "You start morphing.";
			TalkBox.TalkBoxTextString = "Que estoy sintiendo por tiiii...(♫)";
		}
		else if (DanceNmb == 8) {
			DanceTxt2 = "You are 50%RealNoFake.";
			TalkBox.TalkBoxTextString = "Que te quiero que te adoro...(♫)";
		}
		else if (DanceNmb == 9) {
			DanceTxt2 = "You are 75%RealNoFake.";
			TalkBox.TalkBoxTextString = "Que eres la mujer que he soñado...(♫)";
		}
		else if (DanceNmb == 10) {
			DanceTxt2 = "You are 100%RealNoFake.";
			TalkBox.TalkBoxTextString = "Que me haces muy feliiiz...(♫)";
		}
		else if (DanceNmb == 11) {
			DanceTxt2 = "He spared you.";
			TalkBox.TalkBoxTextString = "♫♫♫♫♫♫";
			MainMenTxt.Txt = "He Spared you.";
		}
		else if(DanceNmb == 12){
			Spareable = true;
			Music.Stop ();

		}


	}

	public void ActMove ()
	{   GameObject act = GameObject.Find ("ActMove");
		Act Script = act.GetComponent<Act> ();
		UITextTypeWriterName Nam = Name.GetComponent<UITextTypeWriterName> ();
		UITextTypeWriterDesc Des = Desc.GetComponent<UITextTypeWriterDesc> ();
		UITextTypeWriterDance DanceType = Script.Dance_Text.GetComponent<UITextTypeWriterDance> ();
		UITextTypeWriter x = xAct.GetComponent<UITextTypeWriter> ();

		Item IScript = ItemI.GetComponent<Item> ();

		SpriteRenderer SpR = gameObject.GetComponent<SpriteRenderer> ();
		Animator TxtAnim = TextBox.GetComponent<Animator> ();

		Attacks Attack = Attacks.GetComponent<Attacks> ();

		if (Script.OnActMenuNmb == 2) {//*Check *Dance
			if (Input.GetAxisRaw ("Horizontal") == 1) {
				if (gameObject.transform.position == Script.ActPos1.transform.position) {
					if (IScript.NOfClicks > 1) {
						//if (KeyPressed == false) {
						gameObject.transform.position = Script.ActPos3.transform.position;
					
						//}
	
					}
			
				}
			}
			if (Input.GetAxisRaw ("Horizontal") == -1) {
				if (gameObject.transform.position == Script.ActPos3.transform.position) {
					if (IScript.NOfClicks > 1) {
						gameObject.transform.position = Script.ActPos1.transform.position;
				
					}
		
				}
			}
		}



			if (Input.GetAxisRaw ("Cancel") == 1) {
			
				if (Script.OnActMenuNmb == 1) {//Name of enemy
				
					if (IScript.NOfClicks > 1) {

						gameObject.transform.position = Act1.transform.position;
						Act1.interactable = true;
						Script.OnActMenuNmb = 0;
						Act1.enabled = true;
						Act1.Select ();
						MainMenuTxt Main = GetComponent<MainMenuTxt> ();
						Main.MainMenTxt ();
					}
				}
				if (Script.OnActMenuNmb == 2) {//*Check and *Dance
				
					Script.OnActMenuNmb = 1;
					Script.ActText1.enabled = true;//Name of enemy
					Script.Check.enabled = false;//Check
					IScript.NOfClicks = 1;
					SelectFX.Play ();
					Script.XCheck.enabled = false;//* in *Check
					Script.Dance.enabled = false;//Dance
					Script.XDance.enabled = false;//* in *Dance
				}
			}
			if (Input.GetAxisRaw ("Cancel") == 0) {
				if (Script.OnActMenuNmb != 0) {
				}
			}
			if (Input.GetAxisRaw ("Submit") == 1) {
				if (IScript.NOfClicks > 1) {
				Attack.CancelSpawn=false;
					if (Script.OnActMenuNmb == 1) {//Name Of Enemy
						gameObject.transform.position = Script.ActPos1.transform.position;
						Script.Check.enabled = true;//In Act GameObject//Check
						Script.XCheck.enabled = true;//* in *Check
						Script.Dance.enabled = true;//Dance
						Script.XDance.enabled = true;//* in *Dance
						Script.ActText1.enabled = false;//Name of enemy
						IScript.NOfClicks = 1;
						SelectFX.Play ();
						Script.OnActMenuNmb = 2;
					}
				}
				if (Script.OnActMenuNmb == 2) {//*Check *Dance
					if (gameObject.transform.position == Script.ActPos1.transform.position) {//In *Check
						if (IScript.NOfClicks > 1) {
							//gameObject.SetActive (false);(Breaks other things)
							Script.Check.enabled = false;
							Act1.enabled = true;
							Act1.enabled = false;//So the Act button stays uninteractable AND orange
							Name.enabled = true;//Name part of Check
							Nam.ChangeText (Nam.text, 0f);
							Script.OnActMenuNmb = 0;
						    SpR.enabled = false;//Sprite Render of heart
							ReadingAct = true;
							Script.Dance.enabled = false;//Dance
							Script.XDance.enabled = false;//* in *Dance
						Script.XCheck.enabled=false;
						IScript.NOfClicks = 1;
						}
					}
					if (gameObject.transform.position == Script.ActPos3.transform.position) {//In Dance
					SpR.enabled = false;//Sprite Render of heart
					ReadingDance = true;
					Script.OnActMenuNmb = 0;
					Script.Check.enabled = false;
					Script.Check.enabled = false;//In Act GameObject//Check
					Script.XCheck.enabled = false;//* in *Check
					Script.Dance.enabled = false;//Dance
					Script.XDance.enabled = false;//* in *Dance
					Script.Dance_Text.enabled = true;//Dance Text
					Script.XDance_Text.enabled = true;//* In Dance Text
					DanceType.ChangeText(DanceTxt,0f);
					IScript.NOfClicks = 1;

					}

				}
			}
			if (Input.GetAxisRaw ("Submit") == 0 && Input.GetAxisRaw ("Cancel") == 0) {
				IScript.NOfClicks = 2;
			
			}
		}

	public void ItemMove ()
	{
		ItemUsage Item = ItemUsage.GetComponent<ItemUsage> ();
		GameObject item = GameObject.Find ("ItemMove");
		Item Script = item.GetComponent<Item> ();
		Attacks Attack = Attacks.GetComponent<Attacks> ();
//		if(Script.OnItemMenu){
//			if (Input.GetAxis("Submit") > 0) {
//				
//			}
//		}
//

		if (Script.OnItemMenu) {
			if (Input.GetAxisRaw ("Cancel") == 1) {
				
					ItemExit ();

				Script.OnItemMenu = false;


			}
			if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical")==0 ){
				KeyPressed = false;

			}



			if (Input.GetAxisRaw("Horizontal") == 1) {
				if (Item.IsItem1 && Item.IsItem2 && Item.IsItem3 || Item.IsItem4 && Item.IsItem2 && Item.IsItem3 || Item.IsItem1 && Item.IsItem3 && Item.IsItem4 || Item.IsItem1 && Item.IsItem2 && Item.IsItem4) 
				{
				} 
				else {
					if (gameObject.transform.position == Pos1.transform.position) {
						if(Script.NOfClicks > 1){
							if(KeyPressed==false){
							gameObject.transform.position = Pos3.transform.position;
							SelectFX.Play ();
							HeartPos = 3;
						}
						}}
						else if (gameObject.transform.position == Pos2.transform.position) {
						if (Item.IsItem1 == false && Item.IsItem2 == false && Item.IsItem3 == false && Item.IsItem4 == false) {
							gameObject.transform.position = Pos4.transform.position;
							SelectFX.Play ();
							HeartPos = 4;
						}
					}
				}
			} else if (Input.GetAxisRaw("Horizontal") == -1) {
				if (gameObject.transform.position == Pos3.transform.position) {
					gameObject.transform.position = Pos1.transform.position;
					SelectFX.Play ();
					HeartPos = 1;
				} 
				else if (gameObject.transform.position == Pos4.transform.position) {
					gameObject.transform.position = Pos2.transform.position;
					SelectFX.Play ();
					HeartPos = 2;
				}
//				else if (gameObject.transform.position == Pos1.transform.position){//I HAVE TO FIX THIS NEEDS FIX THIS NEEDS TO BE FIXED.
				//					gameObject.transform.position = Pos3.transform.position;//I HAVE TO FIX THIS NEEDS FIX THIS NEEDS TO BE FIXED.
				//					SelectFX.Play ();//I HAVE TO FIX THIS NEEDS FIX THIS NEEDS TO BE FIXED.
				//					HeartPos = 3;//I HAVE TO FIX THIS NEEDS FIX THIS NEEDS TO BE FIXED.
				//				}//I HAVE TO FIX THIS NEEDS FIX THIS NEEDS TO BE FIXED.

			} 
			else if (Input.GetAxisRaw("Vertical") == -1) {
				if (Item.IsItem1 && Item.IsItem2 && Item.IsItem3 || Item.IsItem4 && Item.IsItem2 && Item.IsItem3 || Item.IsItem1 && Item.IsItem3 && Item.IsItem4 || Item.IsItem1 && Item.IsItem2 && Item.IsItem4 || Item.IsItem1 && Item.IsItem2 || Item.IsItem3 && Item.IsItem4 || Item.IsItem1 && Item.IsItem4 || Item.IsItem3 && Item.IsItem1) { 
					
				}
				else {
					if (gameObject.transform.position == Pos1.transform.position) {
						if(Script.NOfClicks > 1){
							if(KeyPressed==false){
						gameObject.transform.position = Pos2.transform.position;
						SelectFX.Play ();
						HeartPos = 2;
							}}}
				}
			
			
			 if (gameObject.transform.position == Pos3.transform.position) {
				if (Item.IsItem1 == false && Item.IsItem2 == false && Item.IsItem3 == false && Item.IsItem4 == false) {
					gameObject.transform.position = Pos4.transform.position;
					SelectFX.Play ();
						HeartPos = 4;
				}
				} }
			else if (Input.GetAxis ("Vertical") == 1) {
				if (gameObject.transform.position == Pos4.transform.position) {
					SelectFX.Play ();
					gameObject.transform.position = Pos3.transform.position;
					HeartPos = 3;
				} 
				else if (gameObject.transform.position == Pos2.transform.position) {
				
					gameObject.transform.position = Pos1.transform.position;
					SelectFX.Play ();
					HeartPos = 1;
				}
			}
		}


				}
	public void ItemExit(){

		GameObject item = GameObject.Find ("ItemMove");
		Item Script = item.GetComponent<Item> ();
		gameObject.transform.position = Item1.transform.position;
		Item1.interactable = true;
		Script.OnItemMenu = false;
		Item1.enabled = true;
		Item1.Select ();
		MainMenuTxt Main = GetComponent<MainMenuTxt> ();
		Main.MainMenTxt ();
		Script.NOfClicks = 0;
		HeartPos = 0;
	
	}
			}
			
		
	
	

