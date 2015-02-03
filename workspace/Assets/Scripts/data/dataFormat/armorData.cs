using UnityEngine;
using System.Collections;

public class armorData {
	public armorData(){
		}

	public string 		name;			
	public int			armorID;		
	public int			armorType;	
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


	public armorData(armorData data)
	{

		name 			= data.name;
		armorID 		= data.armorID;
		armorType 		= data.armorType;
		armorGrade 		= data.armorGrade;
		armorHP			= data.armorHP;
		def 			= data.def;
		mDef 			= data.mDef;
		mAtk 			= data.mAtk;
		critChance 		= data.critChance;
		hpRegen 		= data.hpRegen;
		potionup 		= data.potionup;
		shield 			= data.shield;
		critOnEnemy 	= data.critOnEnemy;
		slow 			= data.slow;
		thorns 			= data.thorns;
		chargeAtk		= data.chargeAtk;

	}


	~armorData(){}

}
