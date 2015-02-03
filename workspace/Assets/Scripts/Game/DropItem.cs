using UnityEngine;
using System;
using System.Collections;

public class DropItem : MonoBehaviour {
	float 				RandY;
	float 				maxiamDistance;
	public float 		speed = 1f;
	//Data Load
	armorDataLoad 		m_ItemDataLoad;
	public armorData 	m_ItemData;
	int[] 				Item_load_info;
	int					ChooseItemId;
	//Item Info
	public struct ITEM
	{
		public string 		name;
		public int			armorID;
		public int			armorType; // 0 : cap, 1 : robe, 2 : shoes, 3 : cloack
		public int			armorGrade;
		public int			armorHP;
		public int			def;
		public int			mDef;
		public int			mAtk;
		public float		critChance;
		public float		hpRegen;
		public float		potionup;
		public int			shield;
		public int			critOnEnemy;
		public int			slow;
		public int			thorns;
		public int			chargeAtk;
	}
	public ITEM m_item;
	// Use this for initialization
	void Awake() 
	{
		m_ItemDataLoad = new armorDataLoad ();
		m_ItemDataLoad.Load ();
		RandY = UnityEngine.Random.Range (0, 2);
		maxiamDistance = gameObject.transform.position.x - 20;
		ChooseToArmor ();
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
	
	void ChooseToArmor()
	{
		Item_load_info = new int[StageManager.GetInstance().m_stageData.treasureID.Length];
		for(int i = 0; i < StageManager.GetInstance().m_stageData.treasureID.Length; i++)
		{
			Item_load_info[i] = Convert.ToInt32(StageManager.GetInstance().m_stageData.treasureID[i]);
		}
		int temp = UnityEngine.Random.Range (0, Item_load_info.Length);
		ChooseItemId = Item_load_info [temp];
		m_ItemData = m_ItemDataLoad.GetArmorData (ChooseItemId);
		GetArmorInfo (m_ItemData);
	}

	void GetArmorInfo(armorData tempData)
	{
		m_item.name				= tempData.name;			
		m_item.armorID			= tempData.armorID;		
		m_item.armorType		= tempData.armorType;	
		m_item.armorGrade		= tempData.armorGrade;		
		m_item.armorHP			= tempData.armorHP;			
		m_item.def				= tempData.def;			
		m_item.mDef				= tempData.mDef;			
		m_item.mAtk				= tempData.mAtk;			
		m_item.critChance		= tempData.critChance;			
		m_item.hpRegen			= tempData.hpRegen;			
		m_item.potionup			= tempData.potionup;			
		m_item.shield			= tempData.shield;			
		m_item.critOnEnemy		= tempData.critOnEnemy;		
		m_item.slow				= tempData.slow;			
		m_item.thorns			= tempData.thorns;			
		m_item.chargeAtk		= tempData.chargeAtk;
		Debug.Log (m_item.armorType);
	}
}
