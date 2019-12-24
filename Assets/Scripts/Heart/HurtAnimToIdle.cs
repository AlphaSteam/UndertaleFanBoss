using UnityEngine;
using System.Collections;

public class HurtAnimToIdle : MonoBehaviour {
	public GameObject Heart;
	public float duration = 0;
	public GameObject TextBox;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Animator Attack_0 = gameObject.GetComponent<Animator> ();
		PlayerHealth Health = Heart.GetComponent<PlayerHealth> ();
		BattleExit BE = TextBox.GetComponent<BattleExit> ();

		if(Health.Invulnerable){
			if (BE.InBattle) {
			
				StartCoroutine ("Idle", duration);
			}
			else {
				StopAllCoroutines ();
				Attack_0.Play ("Idle");
				Health.Invulnerable = false;
			}
		}
	}
	IEnumerator Idle(float duration){
		Animator Attack_0 = gameObject.GetComponent<Animator> ();
		PlayerHealth Health = Heart.GetComponent<PlayerHealth> ();
		yield return new WaitForSeconds (duration);
		Attack_0.Play ("Idle");
		Health.Invulnerable = false;
		StopAllCoroutines ();

	
	}
}
