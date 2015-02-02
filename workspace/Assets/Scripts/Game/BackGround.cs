using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour 
{
	float speed = 5f; // second per 5meter
	float resetDistance; 
	float initialDistance;


	// Use this for initialization
	void Awake() 
	{
		initialDistance = gameObject.transform.position.x;
		resetDistance = gameObject.transform.position.x - 18f;
	}
	
	// Update is called once per frame
	void Update ()  
	{  
		float move = speed * Time.deltaTime; 
		gameObject.transform.Translate(Vector3.left * move, Space.World);  
		if (gameObject.transform.position.x < resetDistance)  
		{  
			gameObject.transform.position = new Vector3(initialDistance, gameObject.transform.position.y, gameObject.transform.position.z);  
		}  
	}  
}
