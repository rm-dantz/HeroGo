using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	float speed = 1;
	float maxiamDistance; 
	void Awake() 
	{
		maxiamDistance = gameObject.transform.position.x - 15;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float move = speed * Time.deltaTime; 
		gameObject.transform.Translate(Vector3.left * move, Space.World);
		if (gameObject.transform.position.x < maxiamDistance) 
		{
			Destroy(gameObject);
		}
	}
}
