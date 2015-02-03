using UnityEngine;
using System.Collections;

public class amor_d_info : ItemInterface
{
	// Use this for initialization
	public amor_d_info()
	{
		name 			= "noname cloak";			
		armorID 		= 0;		
		armorType 		= 4;	
		armorGrade 		= 0;		
		armorHP			= 10;			
		def 			= 0;			
		mDef 			= 0;			
		mAtk 			= 0;			
		critChance 		= 0;			
		hpRegen 		= 0;			
		potionup 		= 0;			
		shield 			= 0;			
		critOnEnemy 	= 0;		
		slow 			= 0;			
		thorns 			= 0;			
		chargeAtk 		= 0;	
	}
	
	public override void replace(GameObject Info)
	{
		Debug.Log ("Complete cloack");
		name = Info.gameObject.GetComponent<DropItem> ().m_item.name;
		armorID = Info.gameObject.GetComponent<DropItem> ().m_item.armorID;
		armorType = Info.gameObject.GetComponent<DropItem> ().m_item.armorType;
		armorGrade = Info.gameObject.GetComponent<DropItem> ().m_item.armorGrade;
		armorHP = Info.gameObject.GetComponent<DropItem> ().m_item.armorHP;
		def = Info.gameObject.GetComponent<DropItem> ().m_item.def;
		mDef = Info.gameObject.GetComponent<DropItem> ().m_item.mDef;
		mAtk = Info.gameObject.GetComponent<DropItem> ().m_item.mAtk;
		critChance = Info.gameObject.GetComponent<DropItem> ().m_item.critChance;
		hpRegen = Info.gameObject.GetComponent<DropItem> ().m_item.hpRegen;
		potionup = Info.gameObject.GetComponent<DropItem> ().m_item.potionup;
		shield = Info.gameObject.GetComponent<DropItem> ().m_item.shield;
		critOnEnemy = Info.gameObject.GetComponent<DropItem> ().m_item.critOnEnemy;
		slow = Info.gameObject.GetComponent<DropItem> ().m_item.slow;
		thorns = Info.gameObject.GetComponent<DropItem> ().m_item.thorns;
		chargeAtk = Info.gameObject.GetComponent<DropItem> ().m_item.chargeAtk;
	}
}
