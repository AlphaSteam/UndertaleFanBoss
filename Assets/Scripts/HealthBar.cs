using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {
	public float MaxLife;
	public float CurrentHealth;
	public float PHealth;
	public Image HBar;
	public GameObject Player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		PlayerHealth Health = Player.GetComponent<PlayerHealth> ();
		PHealth = Health.PHealth;
		CurrentHealth =Health.PHealth/MaxLife;
		HBar.fillAmount = CurrentHealth;
		if(Health.PHealth>MaxLife){
			Health.PHealth = (int) MaxLife;


		}



	}

}
