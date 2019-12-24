using UnityEngine;
using System.Collections;

public class Miss : MonoBehaviour {
	public GameObject AtkDamage;
	// Use this for initialization
	void OnEnable () {
		BattleFight BF = AtkDamage.GetComponent<BattleFight> ();
		BF.enabled = true;
		BF.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
