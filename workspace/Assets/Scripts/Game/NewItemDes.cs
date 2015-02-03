using UnityEngine;
using System.Collections;

public class NewItemDes : MonoBehaviour {
	//Item Info 0 : cap, 1 : robe, 2 : shoes, 3 : cloack
	public GameObject GetItem;
	public GameObject DropItem;

	public void Init()
	{
		gameObject.GetComponent<UILabel> ().text = 
			"Name : " + DropItem.gameObject.GetComponent<DropItem>().m_item.name + " \n " +
				"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.armorHP  + " \n " +
				"Defence : " + DropItem.gameObject.GetComponent<DropItem>().m_item.def  + " \n " +
				"Damage : " + DropItem.gameObject.GetComponent<DropItem>().m_item.mAtk  + " \n " +
				"Cri : " + DropItem.gameObject.GetComponent<DropItem>().m_item.critChance  + " \n " +
				"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.hpRegen  + " \n " +
				"Barrier : " + DropItem.gameObject.GetComponent<DropItem>().m_item.shield  + " \n " +
				"Potion_up : " + DropItem.gameObject.GetComponent<DropItem>().m_item.potionup;

	}
	// Update is called once per frame
	void Update() 
	{
		
	}
}
