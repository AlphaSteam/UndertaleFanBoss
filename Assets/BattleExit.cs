using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BattleExit : MonoBehaviour {
	//In TextBox GameObject
	public bool InBattle = false;
	public Text x;
	public GameObject Heart;
	public Button Fight;
	public Button Mercy;
	public Button Item;
	public Button Act;
	public Transform FightPos;
	public Animator AtkDamage;
	public Animator Atk_0;
	public Animator BattleBg;
	public Animator BarAnim;
	public Animator TextBoxAnim;
	public GameObject ItemUsage;
	public GameObject NoLostFocus;
	public Attacks Attack;
	GameObject lastselect2;
	// Use this for initialization
	void Start () {
		lastselect2 = new GameObject();
	}
	
	// Update is called once per frame
	void Update () {
		//BattleE ();
		if(EventSystem.current.currentSelectedGameObject != null){
		lastselect2 =EventSystem.current.currentSelectedGameObject;

		}}

	public void BattleE(){
		
		Animator BoxAnim = gameObject.GetComponent<Animator> ();
		if (InBattle == false) {
			BoxAnim.Play ("TextBox1Reverse");
		} 
		else if (InBattle) {
		
			BoxAnim.Play ("TextBox1");
		}
	
	}
	IEnumerator BattleDuration(float duration){
		yield return new WaitForSeconds (duration);
		UITextTypeWriter Type = gameObject.GetComponent<UITextTypeWriter> ();
		MainMenuTxt MenTxt = Heart.GetComponent<MainMenuTxt> ();
		TalkBox TalkB = gameObject.GetComponent<TalkBox> ();//TalkBox
		MainMenuTxt Main = Heart.GetComponent<MainMenuTxt> ();
		HitSound Hs = Atk_0.GetComponent<HitSound> ();
		ItemUsage IU = ItemUsage.GetComponent<ItemUsage> ();
		Initialise_Button IB = NoLostFocus.GetComponent<Initialise_Button> ();
		//Attacks Atk = Attack.GetComponent<Attacks> ();

		InBattle = false;
		Fight.enabled = true;
		Fight.interactable = true;
		Act.enabled = true;
		Act.interactable = true;
		Mercy.enabled = true;
		Mercy.interactable = true;
		Item.enabled = true;
		Item.interactable = true;
		if(lastselect2.ToString() == "Fight"){
			Fight.Select ();
		}
		else if (lastselect2.ToString() == "Act"){
			Act.Select ();
		}
		else if (lastselect2.ToString() == "Item"){
			Item.Select ();
		}
		else if (lastselect2.ToString() == "Mercy"){
			Mercy.Select ();
		}
		Heart.transform.position = FightPos.position;
		//AtkDamage.Stop ();
		Atk_0.enabled = false;
		//BattleBg.enabled = false;
		TextBoxAnim.Play ("TextBox1Reverse");
		Hs.enabled = false;
		IU.Item1_2Finished = false;
		Main.Neutral += 1;
		TalkB.TalkingProgress = false;
		Attack.CancelSpawn = true;
		Attack.RemoveLaser ();
		//yield return true;


	}
}
