using UnityEngine;
using System.Collections;

public class TimeCounting : MonoBehaviour {
	public float Limit_Second;
	//Monster Level
	public int Monster_Level;
	// Use this for initialization
	void Awake() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		Limit_Second -= Time.deltaTime;
		if(Limit_Second <= 0)
		{
			Monster_Level++;
			Limit_Second = 10f;
		}
	}
}
