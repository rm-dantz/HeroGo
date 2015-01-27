using UnityEngine;
using System.Collections;

public class ItemInterface : MonoBehaviour 
{
	//public info item_info;
	public string 	Item_Name;
	public float 	HP;
	public float 	Defence;
	public float	MagicDefence;
	public int 		Damage;
	public int 		Cri;
	public int 		HP_Regen;
	public int 		Barrier;
	public int 		Potion_Up;
	public int 		Item_Type;

	// Use this for initialization
	public virtual void replace()
	{
	}
}
