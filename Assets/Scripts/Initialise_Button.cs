using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Initialise_Button : MonoBehaviour {
	GameObject lastselect;
	public GameObject MercyMove;
	public GameObject ActMove;
	public GameObject ItemMove;
	public GameObject FightMove;
	public GameObject TextBox;
	public Text QuittingTxt;
	public bool Mouse = false;
	public float Tme;
	void Start()
	{
		lastselect = new GameObject();
	}
	// Update is called once per frame
	void Update () {  // AudioSource Sm=gameObject.GetComponent<AudioSource>();
		Mercy Mer=MercyMove.GetComponent<Mercy>();
		Act Ac = ActMove.GetComponent<Act> ();
		Item Ite = ItemMove.GetComponent<Item> ();
		Fight Fig = FightMove.GetComponent<Fight> ();
		BattleExit BE = TextBox.GetComponent<BattleExit> ();
		MouseFunc();
		Quitting ();


		if(Mer.OnMercyMenu==false && Ite.OnItemMenu == false && Ac.OnActMenuNmb == 0 && Fig.OnFightMenu == false){
			if(BE.InBattle==false){
			if (EventSystem.current.currentSelectedGameObject == null)
		{
			EventSystem.current.SetSelectedGameObject(lastselect);
		}
		else
		{
			lastselect = EventSystem.current.currentSelectedGameObject;
		}
			}}}
	public void MouseFunc(){
		
		if (Input.GetButtonDown ("Fire1")) {
			Mouse = true;
		}
		if (Input.GetButtonUp ("Fire1")) {
			Mouse = false;
		}
		}
	public void Quitting(){
		
		if (Input.GetAxisRaw("Esc") == 1) {
			QuittingTxt.enabled = true;
			Tme += Time.deltaTime;
			if(Tme>1.5f){
				Application.Quit ();
				}
		}

		if (Input.GetAxis("Esc")==0) {
			QuittingTxt.enabled = false;
			Tme = 0;
		}

	}
	
	
}