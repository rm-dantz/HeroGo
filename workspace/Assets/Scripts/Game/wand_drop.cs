using UnityEngine;
using System.Collections;

public class wand_drop : MonoBehaviour {
	float RandY;
	float maxiamDistance;
	public float speed = 1f;
	public float transitionTime = 0.5f;
	//public int startElement = 1;
	public int currentElement;
	float dTime = 0f;

	// Use this for initialization
	void Awake() 
	{
		currentElement = 1;
		RandY = 1;//Random.Range (0, 2);
		maxiamDistance = gameObject.transform.position.x - 20;
	}
	
	// Update is called once per frame
	void Update() 
	{
		dTime += Time.deltaTime;
		if (dTime > transitionTime) {
			currentElement = Random.Range(1,4);
			//Debug.Log(currentElement);
			dTime = 0;
		}
		if (currentElement == 1) {
			this.GetComponentInChildren<SpriteRenderer>().color = Color.red;
		} 
		else if (currentElement == 2) {
			this.GetComponentInChildren<SpriteRenderer>().color = Color.green;
		} 
		else {
			this.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
		}


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
