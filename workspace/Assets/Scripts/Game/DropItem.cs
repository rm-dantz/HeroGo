using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {
	float RandY;
	float maxiamDistance;
	public int Type; // 0 : cap, 1 : robe, 2 : shoes, 3 : cloack
	public float speed = 1f;
	int Grade;
	int Support_Option;
	int Special_Option;
	int Item_Level = 10;
	//Item Info
	public struct ITEM
	{
		public string 	Item_Name;
    	public int 		HP;
    	public float 	Defence;
		public float	MagicDefence;
    	public int 		Damage;
    	public int 		Cri;
    	public int 		HP_Regen;
    	public int 		Barrier;
    	public int 		Potion_Up;
    	public int 		Item_Type;
	}
	public ITEM m_item;
	// Use this for initialization
	void Awake() 
	{
		m_item.Item_Name = "normal";
		m_item.HP = 25;
		m_item.Defence = 1f;
		m_item.MagicDefence = 1f;
		m_item.Damage = 0;
		m_item.Cri = 0;
		m_item.HP_Regen = 0;
		m_item.Barrier = 0;
		m_item.Potion_Up = 0;
		Type = Random.Range (1, 5);
		RandY = Random.Range (0, 2);
		maxiamDistance = gameObject.transform.position.x - 20;
		ChangeToOoption ();
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

	public void ChangeToOoption()
	{
		Grade = Random.Range (0, 4);
		
		switch (Grade) 
		{
		case 0: // Common
		{
			m_item.HP += Item_Level;
			m_item.Defence += Item_Level;
			break;
		}
		case 1: // UnCommon
		{
			m_item.HP += Item_Level;
			m_item.Defence += Item_Level;
			Support_Option = Random.Range (0, 5);
			SetSupportOption(Support_Option);
			break;
		}
		case 2: // Rare
		{
			m_item.HP += Item_Level;
			m_item.Defence += Item_Level;
			Special_Option = Random.Range (0, 5);
			SetSpecialOption(Special_Option);
			break;
		}
		case 3: // Legendary
		{
			m_item.HP += Item_Level;
			m_item.Defence += Item_Level;
			Support_Option = Random.Range (0, 5);
			SetSupportOption(Support_Option);
			Special_Option = Random.Range (0, 5);
			SetSpecialOption(Special_Option);
			break;
		}
		}
	}
	
	public void SetSupportOption(int SupportOptionLevel)
	{
		switch (SupportOptionLevel) 
		{
		case 0:
		{
			m_item.Damage += Item_Level;
			break;
		}
		case 1:
		{
			m_item.Cri += Item_Level;
			break;
		}
		case 2:
		{
			m_item.HP_Regen += Item_Level;
			break;
		}
		case 3:
		{
			m_item.Barrier += Item_Level;
			break;
		}
		case 4:
		{
			m_item.Potion_Up += Item_Level;
			break;
		}
		}
	}
	
	public void SetSpecialOption(int SpecialOptionLevel)
	{
		switch (SpecialOptionLevel) 
		{
		case 0:
		{
			
			break;
		}
		case 1:
		{
			
			break;
		}
		case 2:
		{
			
			break;
		}
		case 3:
		{
			
			break;
		}
		case 4:
		{
			
			break;
		}
		}
	}

}
