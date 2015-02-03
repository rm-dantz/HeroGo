using UnityEngine;
using System;
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
	float RegenDelay = 0f;
	//Data Load
	stageDataLoad 		m_ParseStage;
	public stageData 	m_stageData;
	//BackGround Move Speed
	static float BackGround_Speed = 5f;
	public float Reset_Distance = 0f;
	float Limit_Distance = 0f;
	float SecondPerMeter = 0f;
	int Stage_Level = 1;
	//Monster Generate
	monsterGenerator m_monsterCreate;
	int[] Monster_load_info;
	int ChooseMonsterId;
	//Singleton
	public static StageManager getInstance;
	// Use this for initialization
	void Awake() 
	{
		m_ParseStage = new stageDataLoad ();
		m_ParseStage.Load ();
		m_monsterCreate = new monsterGenerator ();
		m_stageData = m_ParseStage.GetStageData (Stage_Level);
		Limit_Distance = Reset_Distance;
		getInstance = this;

	}
	
	// Update is called once per frame
	void Update() 
	{
		DropDelay += Time.deltaTime;
		if(DropDelay > 5f)
		{
			RandY = UnityEngine.Random.Range (-1f, 2.5f);
			BoxPos = new Vector3 (13, RandY, 0);
			Instantiate (m_boxObj, BoxPos, Quaternion.identity);
			DropDelay = 0f;
		}

		wandDelay += Time.deltaTime;
		if(wandDelay > 4f)
		{
			RandY = UnityEngine.Random.Range (-1f, 2.5f);
			wandPos = new Vector3 (13, RandY, 0);
			Instantiate (m_wandObj, wandPos, Quaternion.identity);
			wandDelay = 0f;
		}

		RegenDelay += Time.deltaTime;
		if(RegenDelay > 5f)
		{
			MonsterCreate();
			RegenDelay = 0f;
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
			Debug.Log("Now Stage : " + Stage_Level);
		}
	}

	void MonsterCreate()
	{
		Monster_load_info = new int[m_stageData.monsterList.Length];
		for(int i = 0; i < m_stageData.monsterList.Length; i++)
		{
			Debug.Log (m_stageData.monsterList[i]);
			Monster_load_info[i] = Convert.ToInt32(m_stageData.monsterList[i]);
		}
		int temp = UnityEngine.Random.Range (0, Monster_load_info.Length);
		ChooseMonsterId = Monster_load_info[temp];
		//Debug.Log (ChooseMonsterId);
		m_monsterCreate.Generate (ChooseMonsterId);

	}
	public static StageManager GetInstance()  
	{
		return getInstance;
	}
}
