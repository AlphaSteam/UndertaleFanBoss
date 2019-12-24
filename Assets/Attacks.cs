using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attacks : MonoBehaviour {
	public int AttackNumber;
	public GameObject TextBox;
	public GameObject LaserGreen;
	public Transform spawnLU;
	public Transform spawnLD;
	public Transform spawnRU;
	public Transform spawnRD;
	public bool LaserSpawn=false;
	public bool CancelSpawn = false;
	public Vector3 LaserForce = new Vector3 (0,1,0);

	public float Tme;
	public Transform Attack1Parent;
	public float speed=.5f;
	public List<GameObject>Lasers=new List<GameObject>();
	public int n;

	public GameObject EnemyH;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		SpawnLaser ();
		//n = Lasers.Count;

	}
	public void RemoveLaser(){
		
			
			
	}
	public void ChoseAttack(){
		int r = Random.Range (0, 0);
		if (r == 0) {
			SpawnNLasers (Random.Range (1, 4));
		}
	
	
	}
	public void SpawnNLasers(int n){
		
		while (n>=0)
		{
			LaserSpawn=true;
				SpawnLaser ();
				n = n - 1;
				
			}
		}
	

	public void SpawnLaser(){
		BattleExit BE = TextBox.GetComponent<BattleExit> ();
		SpriteRenderer LG = LaserGreen.GetComponent<SpriteRenderer> ();
		HealthBar_Enemy HB = EnemyH.GetComponent<HealthBar_Enemy> ();
		if (BE.InBattle) {
			if (LaserSpawn) {
				LG.enabled = true;
				Vector3 LaserPosition = new Vector3 (Random.Range (spawnLU.position.x, spawnRU.position.x), spawnLU.position.y, 0);
				LaserSpawn = false;
				GameObject LaserClone = (GameObject)Instantiate (LaserGreen, LaserPosition, Quaternion.identity);
				//Rigidbody2D LCRB = LaserClone.AddComponent <Rigidbody2D>()as Rigidbody2D;
				//LCRB.AddForce (LaserForce);
				LaserClone.transform.SetParent (Attack1Parent);
				Lasers.Add (LaserClone);
				for (int i = 0; i < Lasers.Count; i++) {
					LaserGreen L = Lasers [i].GetComponent<LaserGreen> ();
					//LaserClone.transform.SetParent (LaserGreenParent);
					LaserClone.name = "Laser " + Lasers.IndexOf (LaserClone);
					LaserClone.tag = "LaserClone";
					L.Tm = 0;


				}
			
//			GameObject LaserC=GameObject.f
			}
		}
		int n = Lasers.Count;
		for (int i = 0; i < n; i++) {
			if (Lasers.Count != 0) {
				Vector3 LaserPosition = new Vector3 (Random.Range (spawnLU.position.x, spawnRU.position.x), Random.Range(spawnLU.position.y,spawnRU.position.y), 0);
				SpriteRenderer S = Lasers[i].GetComponent<SpriteRenderer> ();
				LaserGreen L = Lasers [i].GetComponent<LaserGreen> ();
				if (HB.CurrentHealth != 0) {
					speed = (1 / (HB.CurrentHealth+1));
				}
				Lasers [i].transform.position += LaserForce * speed * Time.deltaTime;
				if (Lasers [i].transform.position.y < spawnLD.position.y) {
					Lasers [i].transform.position = LaserPosition;
					S.enabled = false;

				} else if (Lasers [i].transform.position.y >= spawnLU.position.y) {
					S.enabled = false;
				
				}
				else if(Lasers [i].transform.position.y < spawnLU.position.y)  {
					S.enabled = true;
				
				}
			
				if (CancelSpawn) {
					CancelSpawn = false;
					CancelSpawn = true;
					Destroy (Lasers [0]);
					Lasers.Remove (Lasers [0]);
					Debug.Log (Lasers.Count);
				}
			}
		}
	

		}
	}
