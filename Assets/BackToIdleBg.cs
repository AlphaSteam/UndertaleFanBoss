using UnityEngine;
using System.Collections;

public class BackToIdleBg : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void OnEnable () {
		
		Animator Attack_0 = gameObject.GetComponent<Animator> ();

		Attack_0.Play ("Idle");
		//Attack_0.enabled = false;
	}
}
