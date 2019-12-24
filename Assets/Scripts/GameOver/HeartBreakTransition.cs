using UnityEngine;
using System.Collections;

public class HeartBreakTransition : MonoBehaviour {
	public GameObject CorazonIzq;
	public GameObject CorazonDer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable() {
		HeartBreak ();

	
	}
	void Update(){
		



	}
	public void HeartBreak (){
		Animator CorazonIzqAnim = CorazonIzq.GetComponent<Animator> ();
		Animator CorazonDerAnim = CorazonDer.GetComponent<Animator> ();
		AudioSource Sm = gameObject.GetComponent<AudioSource> ();

		CorazonDerAnim.Play ("HeartBreakRight");
		CorazonIzqAnim.Play ("HeartBreakLeft");
		Sm.Play ();

	}
}
