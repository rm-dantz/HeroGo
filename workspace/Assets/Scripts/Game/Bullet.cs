using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	// Use this for initialization
	public GameObject player_pos;
	float speed = 10;
	float maxiamDistance; 
	void Awake() 
	{
		maxiamDistance = gameObject.transform.position.x + 15;
		gameObject.transform.position = player_pos.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float move = speed * Time.deltaTime; 
		gameObject.transform.Translate(Vector3.right * move, Space.World);
		if (gameObject.transform.position.x > maxiamDistance) 
		{
			Destroy(gameObject);
		}
	}
}
