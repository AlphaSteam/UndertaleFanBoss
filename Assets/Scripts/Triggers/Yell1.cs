using UnityEngine;
using System.Collections;

public class Yell1 : MonoBehaviour {
	public GameObject HitS;//Attack_0
	public Collider2D Bar;
	public GameObject RedHeart;
	// Use this for initialization
	void Start () {

	}


	void OnTriggerStay2D (Collider2D Bar) {
		HeartMove Hm = RedHeart.GetComponent<HeartMove> ();
		HitSound Hs = HitS.GetComponent<HitSound> ();

		if (Hm.Spareable) {

			Hs.Damage = 999999999;
		}
		else {
			Hs.Damage = Random.Range (25000, 30000);
		
		}
	}
}
