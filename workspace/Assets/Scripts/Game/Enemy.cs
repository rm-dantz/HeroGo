using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	//Game time
	public GameObject GameIime;
	//Monster Abillity
	public float speed = 1;
	public int Type = 0;
	public int element = 0;
	public int HP = 10;
	public int Damage = 1;
	public int Level = 1;

	//Destroy Distance
	float maxiamDistance; 

	void Awake() 
	{
		maxiamDistance = gameObject.transform.position.x - 15;
		GameIime = GameObject.Find ("TimeCounting");
		Level += GameIime.gameObject.GetComponent<TimeCounting> ().Monster_Level;
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
			//Destroy (this.gameObject);
		} 
		else if (coll.gameObject.tag == "Bullet") 
		{
			int bulletPower = coll.gameObject.GetComponent<Bullet> ().player_damage;
			Destroy (coll.gameObject);
			HP -= bulletPower;
			if (HP <= 0)
				Destroy (this.gameObject);

		}
	}
	

	
}
