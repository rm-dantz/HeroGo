using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
	//Box Bbj
	public GameObject m_boxObj;
	public GameObject m_wandObj;
	float RandY;
	Vector3 BoxPos;
	Vector3 wandPos;
	float DropDelay = 0f;
	float wandDelay = 0f;
	// Use this for initialization
	void Awake() 
	{

	}
	
	// Update is called once per frame
	void Update() 
	{
		DropDelay += Time.deltaTime;
		if(DropDelay > 2f)
		{
			RandY = Random.Range (-1f, 2.5f);
			BoxPos = new Vector3 (13, RandY, 0);
			Instantiate (m_boxObj, BoxPos, Quaternion.identity);
			DropDelay = 0f;
		}


		wandDelay += Time.deltaTime;
		if(wandDelay > 4f)
		{
			RandY = Random.Range (-1f, 2.5f);
			wandPos = new Vector3 (13, RandY, 0);
			Instantiate (m_wandObj, wandPos, Quaternion.identity);
			wandDelay = 0f;
		}
	}
}
