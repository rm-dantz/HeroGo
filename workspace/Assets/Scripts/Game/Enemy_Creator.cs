using UnityEngine;
using System.Collections;

public class Enemy_Creator : MonoBehaviour {
	public GameObject Slime;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Regen()
	{
		Instantiate (Slime, gameObject.transform.position, Quaternion.identity);
	}

}
