using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
	public Animator TextBox;
	public Text AtkDamage;
	public Image HBEH;
	public Image HBEHDamage;
	public GameObject EnemyHealthBar;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	public void Battle1(){
		BattleExit BatExit = TextBox.GetComponent<BattleExit> ();
		Animator TxtAnim = AtkDamage.GetComponent<Animator> ();
		HealthBar_Enemy HBE = EnemyHealthBar.GetComponent<HealthBar_Enemy> ();
	
		BatExit.InBattle = true;
			TextBox.enabled = true;
			//AtkDamage.enabled = false;
			HBEH.enabled = false;
			HBEHDamage.enabled = false;
			//TxtAnim.enabled = false;


		
	



	}
}
