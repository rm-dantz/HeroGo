using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	// Use this for initialization
	public GameObject player_pos;
	float speed = 10f;
	public int player_damage = 1;
	float maxiamDistance; 

	void Awake() 
	{
		maxiamDistance = gameObject.transform.position.x + 15;
		//player_damage = gameObject.GetComponent<player_control> ().Damage;
		////gameObject.transform.position = player_pos.transform.position;
		//gameObject.transform.position.Set (player_pos.transform.position.x + 1, gameObject.transform.position.y - 1, 0);
	}

	// Update is called once per frame
	void Update () 
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

	void ApplyDamage(int damaged)
	{
		Debug.Log ("asdasd");
	}
}
