using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FightBar : MonoBehaviour {
	
	public Transform target;
	public float speed;
	public GameObject HeartMov;
	public Transform Start;
	public GameObject Item;
	public bool IsMoving = false;
	public Text Miss;
	public GameObject AttackAnim;
	public AudioSource AttackFx;
	public AudioSource AttackHit;

	public BoxCollider2D Red1L;
	public BoxCollider2D Red2R;
	public BoxCollider2D Red1R;
	public BoxCollider2D Bar;
	public GameObject HitS;


	void Update() {
		HitSound Hs = HitS.GetComponent<HitSound> ();


		HeartMove Heart = HeartMov.GetComponent<HeartMove> ();

		SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer> ();
		Animator Anim = gameObject.GetComponent<Animator> ();
		Item IScript =Item.GetComponent<Item> ();


		SpriteRenderer AtkSpr = AttackAnim.GetComponent<SpriteRenderer> ();
		Animator AtkAnim = AttackAnim.GetComponent<Animator> ();

		Animator AnimMiss = Miss.GetComponent<Animator> ();

		if (Input.GetAxisRaw ("Submit") == 0 && Input.GetAxisRaw ("Cancel") == 0) {
			IScript.NOfClicks = 2;
		}
		if (Heart.Attacking) {
			float step = speed * Time.deltaTime;
			if (IsMoving) {
		   transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			}
			if (transform.position == target.transform.position) {
				Heart.Attacking = false;
				transform.position = Start.transform.position;
				spr.enabled = false;
				IsMoving = false;
				Miss.enabled = true;
				AnimMiss.Play ("Miss");
			}
		}


				if (Input.GetAxisRaw ("Submit") == 1) {
			
					if (IScript.NOfClicks > 1) {
				if (Heart.Attacking) {
					
					IsMoving = false;
					Anim.enabled = true;
					AtkSpr.enabled = true;
					AtkAnim.enabled = true;
					AtkAnim.Play("Attack");
					AtkAnim.SetBool("IsAttaking", true);
					AttackFx.Play ();
					IScript.NOfClicks = 1;
					Heart.Attacking = false;

				





				} 
				else {
					//AtkAnim.Play("Idle");
				
				}

			}

		}

	}
}