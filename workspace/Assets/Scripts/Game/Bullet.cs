using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	// Use this for initialization
	float speed = 10f;
	public int player_damage = 0;
	float maxiamDistance; 

	void Awake() 
	{
		maxiamDistance = gameObject.transform.position.x + 15;
	}

	// Update is called once per frame
	void Update() 
	{
		float move = speed * Time.deltaTime; 
		gameObject.transform.Translate(Vector3.right * move, Space.World);
		if (gameObject.transform.position.x > maxiamDistance) 
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy") 
		{
			//Destroy(this.gameObject);
		}
	}
}
