using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitSound : MonoBehaviour {
	public GameObject HBarEn;
	public AudioSource Hit;
	public Text AtkDamage;
	public Image HealthBarHit;
	public Image HealthBarHitDamaged;
	public Animator AtkDamageAnim;
	public GameObject Marciano;
	public GameObject HeartMov;
	public int Damage;
	public Animator Atk;



	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	public void OnEnable () {
		HeartMove Heart = HeartMov.GetComponent<HeartMove> ();
		HealthBar_Enemy HBarE = HBarEn.GetComponent<HealthBar_Enemy> ();
		Animator anim = Marciano.GetComponent<Animator>();
		BattleFight BF = AtkDamage.GetComponent<BattleFight> ();

		Atk.SetBool ("IsAttaking", false);
		Hit.Play ();
		AtkDamage.enabled = true;
		AtkDamageAnim.enabled = true;
		AtkDamageAnim.Play ("AtkDamageAnim");
		HealthBarHit.enabled = true;
		HealthBarHitDamaged.enabled = true;
		anim.Play ("Quake");
		anim.SetBool ("QuakeEna", true);
		HBarE.EHealth -= Damage;
		AtkDamage.text =Damage.ToString();

		//BF.enabled = false;




	}
}
