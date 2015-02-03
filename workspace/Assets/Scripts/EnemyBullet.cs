using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {


	float speed;

	// Use this for initialization
	void Start () {
		speed = 0f;
	}


	public void Init(float _speed){
		speed = _speed;
	}
	// Update is called once per frame
	void Update () {
		float move = speed * Time.deltaTime; 
		gameObject.transform.Translate(Vector3.left * move, Space.World);
		if (gameObject.transform.position.x < -5.5) 
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
				Destroy (this.gameObject);
		} 
	}
}
