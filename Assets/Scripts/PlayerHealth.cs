using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	public int PHealth = 15;
	public GameObject MaxHealth;
	public bool Invulnerable = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HealthBar Health = MaxHealth.GetComponent<HealthBar> ();
		if (PHealth > Health.MaxLife - 1)
		{
			PHealth = (int) Health.MaxLife;
		
		}
		if(PHealth == 0){
			SceneManager.LoadScene (1);

		}
	}
}
