using UnityEngine;
using System.Collections;

public class amor_c_info : ItemInterface
{
	// Use this for initialization
	public amor_c_info()
	{
		Item_Type = 3;
		Item_Name = "normal shoes";
		HP = 25f;
		Defence = 1f;
		MagicDefence = 1f;
		Damage = 0;
		Cri = 0;
		HP_Regen = 0;
		Barrier = 0;
		Potion_Up = 0;
	}
	
	public override void replace(GameObject Info)
	{
		Debug.Log ("Complete shoes");
		Item_Name = Info.gameObject.GetComponent<DropItem> ().m_item.Item_Name;
		HP = Info.gameObject.GetComponent<DropItem> ().m_item.HP;
		Defence = Info.gameObject.GetComponent<DropItem> ().m_item.Defence;
		MagicDefence = Info.gameObject.GetComponent<DropItem> ().m_item.MagicDefence;
		Damage = Info.gameObject.GetComponent<DropItem> ().m_item.Damage;
		Cri = Info.gameObject.GetComponent<DropItem> ().m_item.Cri;
		HP_Regen = Info.gameObject.GetComponent<DropItem> ().m_item.HP_Regen;
		Barrier = Info.gameObject.GetComponent<DropItem> ().m_item.Barrier;
		Potion_Up = Info.gameObject.GetComponent<DropItem> ().m_item.Potion_Up;
	}
}
