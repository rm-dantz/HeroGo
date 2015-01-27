using UnityEngine;
using System.Collections;

public class Enemy_Creator : MonoBehaviour {
	public GameObject Slime;
	public Transform SlimePool;
	// Use this for initialization
	void Awake() {
		
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	public void Regen()
	{
		GameObject SlimeCreation = Instantiate (Slime, gameObject.transform.position, Quaternion.identity) as GameObject;
		SlimeCreation.transform.parent = SlimePool;
	}

}
