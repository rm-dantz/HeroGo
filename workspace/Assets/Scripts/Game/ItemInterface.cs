using UnityEngine;
using System.Collections;

public class ItemInterface : MonoBehaviour 
{
	//public info item_info;
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

	// Use this for initialization
	public virtual void replace(GameObject Info)
	{

	}
}
