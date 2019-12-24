using UnityEngine;
using System.Collections;

public class HealthFragments : MonoBehaviour {
	public GameObject HeartFragments;
	public Vector2 HeartFragmentOffset;
	public GameObject[] Fragment;
	public Vector2[] Forces;
	public float[] RandomValuesX;
	public float[] RandomValuesY;
	public float[] NegativeX;
	public float[]NegativeY;
	public float Tme;
	// Use this for initialization
	void OnEnable() {
		Rigidbody2D RB = HeartFragments.GetComponent<Rigidbody2D> ();
		var NumberOfFragments = Random.Range (7, 9);
		Fragment = new GameObject[NumberOfFragments];
		Forces = new Vector2[NumberOfFragments];
		RandomValuesX = new float[NumberOfFragments];
		RandomValuesY = new float[NumberOfFragments];
		NegativeX = new float[NumberOfFragments];
		NegativeY = new float[NumberOfFragments];
		HeartFragments.SetActive (true);
		HeartFragments.transform.position = HeartMove.HeartPositionTransform;

		for (var i = 0; i < Fragment.Length; i++) {
			HeartFragmentOffset = new Vector2 (i + 5, 0);
			GameObject Clone = (GameObject)Instantiate(HeartFragments, HeartMove.HeartPositionTransform + HeartFragmentOffset, Quaternion.identity);
			Fragment [i] = Clone;
			NegativeX [i] = i;
			NegativeY [i] = i;


			if (NegativeX [i]==0 || NegativeX [i]==2 || NegativeX [i]==6 || NegativeX [i]==7) {
				RandomValuesX [i] = Random.Range (1000, 3000);
			} else {
				RandomValuesX [i] = Random.Range (-3000, -1000);
			}

			if (NegativeY [i]== 1 || NegativeY [i]==3 || NegativeY [i]==6 || NegativeY [i]==7) {
				RandomValuesY [i] = Random.Range (2500, 3000);
			} else {
				RandomValuesY [i] = Random.Range (-2500, -3000);
			}
			

			Forces [i].x = RandomValuesX [i];
			Forces [i].y = RandomValuesY [i];
			Clone.name = "Fragment Number "+ i;
			Rigidbody2D RBC = Clone.GetComponent<Rigidbody2D> ();
			RBC.AddForce (Forces[i]);
		}
		RB.AddForce(RandomForce.Force);
		SpriteRenderer SR = HeartFragments.GetComponent<SpriteRenderer> ();
		SR.enabled=false;
		AudioSource Breaks = gameObject.GetComponent<AudioSource> ();
		Breaks.Play ();
		GameOverCouroutine GOC = HeartFragments.GetComponent<GameOverCouroutine> ();
		GOC.StartCoroutine ("GameOver",2.5);

	}
	// Update is called once per frame
	void Update () {
		Tme += Time.deltaTime;
		if(Tme>6f){
			foreach(var clone in Fragment)
			{
				Destroy(clone);

			}

		}

	}
}