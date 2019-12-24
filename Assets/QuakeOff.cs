using UnityEngine;
using System.Collections;

public class QuakeOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable () {
		Animator anim =GetComponent<Animator>();
		anim.SetBool ("QuakeEna", false);
	}
}
