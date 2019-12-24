using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleFight : MonoBehaviour {
	//Script located in AtkDamage Object
	public GameObject TextBox;
	public Animator FightBg;
	public SpriteRenderer Bar;
	public GameObject Heart;
	public Transform PlayerSpawn;
	public Transform start;
	public Animator TextBoxAnim;
	public GameObject EnemyHealthBar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable () {
		SpriteRenderer Spr = Heart.GetComponent<SpriteRenderer> ();
		HealthBar_Enemy HBE = EnemyHealthBar.GetComponent<HealthBar_Enemy> ();
		Battle Bat = TextBox.GetComponent<Battle> ();

			TextBoxAnim.Play ("TextBox1");
			Animator BarAnim = Bar.GetComponent<Animator> ();
			Bat.Battle1 ();
			FightBg.Play ("BattleBg");
			Bar.enabled = false;
			Bar.transform.position = start.position;
			BarAnim.enabled = false;
			Heart.SetActive (true);
			Spr.enabled = true;
			Heart.transform.position = PlayerSpawn.position;

	}




	}

