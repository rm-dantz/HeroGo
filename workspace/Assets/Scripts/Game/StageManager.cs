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
	//Data Load
	stageDataLoad m_ParseStage;
	stageData m_stageData;
	//BackGround Move Speed
	static float BackGround_Speed = 5f;
	public float Reset_Distance = 0f;
	float Limit_Distance = 0f;
	float SecondPerMeter = 0f;
	int Stage_Level = 1;
	// Use this for initialization
	void Awake() 
	{
		m_ParseStage = new stageDataLoad ();
		m_ParseStage.Load ();
		m_stageData = m_ParseStage.GetStageData (Stage_Level);
		Limit_Distance = Reset_Distance;
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
		ChangeToStageLevel ();
	}

	void ChangeToStageLevel()
	{
		SecondPerMeter = BackGround_Speed * Time.deltaTime;
		Limit_Distance -= SecondPerMeter;
		if( Limit_Distance < 0)
		{
			Limit_Distance = Reset_Distance;
			Stage_Level++;
			m_stageData = m_ParseStage.GetStageData (Stage_Level);
		}
		Debug.Log (Limit_Distance);
	}
}
