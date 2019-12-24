using UnityEngine;
using System.Collections;

public class BackToIdle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable () {
		HitSound Hs = gameObject.GetComponent<HitSound> ();
		Animator Attack_0 = gameObject.GetComponent<Animator> ();
		Hs.enabled = false;
		Attack_0.Play ("Idle");
		Attack_0.enabled = false;
	}
}
