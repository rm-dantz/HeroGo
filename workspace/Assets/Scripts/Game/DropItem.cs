using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {
	float RandY;
	float maxiamDistance;
	public float speed = 1f;
	// Use this for initialization
	void Awake() 
	{
		RandY = Random.Range (0, 2);
		maxiamDistance = gameObject.transform.position.x - 20;
	}
	
	// Update is called once per frame
	void Update() 
	{
		float move = speed * Time.deltaTime; 
		gameObject.transform.Translate(Vector3.left * move, Space.World);
		if (gameObject.transform.position.x < maxiamDistance) 
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			//Time.timeScale = 0;
		} 
	}
}
