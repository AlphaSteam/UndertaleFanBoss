using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBar_Enemy : MonoBehaviour {
	public float MaxLife;
	public float CurrentHealth;
	public float EHealth;
	public Image HBar;
	public Image HbarHit;
	public Animator EnemyAnim;
	public AudioSource Music;
	public bool Dead = false;
	public bool Betrayed = false;
	public GameObject RedHeart;
	public GameObject TextBox;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HeartMove HM = RedHeart.GetComponent<HeartMove>();
		TalkBox TalkBox = TextBox.GetComponent<TalkBox>();
		CurrentHealth =EHealth/MaxLife;
		HBar.fillAmount = CurrentHealth;
		HbarHit.fillAmount = CurrentHealth;
		if(CurrentHealth <= 0){
			
			EnemyAnim.Stop ();
			Music.Stop ();
			CurrentHealth = 0;
			if (HM.Spareable == false) {
				Dead = true;
				TalkBox.TalkBoxTextString = "Ayy lmao :(";
			} 
			else {
				Betrayed = true;
				TalkBox.TalkBoxTextString = "Ayy lmao :(";
			}
		}


	}

}
