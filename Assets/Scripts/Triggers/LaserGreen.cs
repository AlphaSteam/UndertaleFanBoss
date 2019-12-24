using UnityEngine;
using System.Collections;

public class LaserGreen : MonoBehaviour {
	public GameObject Heart;
	public Collider2D Player;
	public AudioSource Hurt;
	public Animator HurtAnim;
	public float Tm=0;
	// Use this for initialization
	void Start () {
		
	}
	void Update(){
		



	}
	void OnTriggerStay2D(Collider2D Player) {
		PlayerHealth Health = Heart.GetComponent<PlayerHealth> ();
		if (Health.Invulnerable == false) {
			Health.PHealth -= 2;
			Debug.Log ("Hit");
			Hurt.Play ();
			HurtAnim.Play ("Hurt");
			Health.Invulnerable = true;
		}

	}
}
