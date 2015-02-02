using UnityEngine;
using System.Collections;

public class NewItemDes : MonoBehaviour {
	//Item Info 0 : cap, 1 : robe, 2 : shoes, 3 : cloack
	public GameObject GetItem;
	public GameObject DropItem;

	public void Init()
	{
		if(GetItem.gameObject.GetComponent<player_control>().NewItemType == 1)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Item_Name + " \n " +
					"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.HP  + " \n " +
					"Defence : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Defence  + " \n " +
					"Damage : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Damage  + " \n " +
					"Cri : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Cri  + " \n " +
					"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.HP_Regen  + " \n " +
					"Barrier : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Barrier  + " \n " +
					"Potion_up : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Potion_Up;

		}
		if(GetItem.gameObject.GetComponent<player_control>().NewItemType == 2)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Item_Name + " \n " +
					"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.HP  + " \n " +
					"Defence : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Defence  + " \n " +
					"Damage : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Damage  + " \n " +
					"Cri : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Cri  + " \n " +
					"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.HP_Regen  + " \n " +
					"Barrier : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Barrier  + " \n " +
					"Potion_up : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Potion_Up;
		}
		if(GetItem.gameObject.GetComponent<player_control>().NewItemType == 3)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Item_Name + " \n " +
					"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.HP  + " \n " +
					"Defence : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Defence  + " \n " +
					"Damage : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Damage  + " \n " +
					"Cri : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Cri  + " \n " +
					"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.HP_Regen  + " \n " +
					"Barrier : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Barrier  + " \n " +
					"Potion_up : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Potion_Up;
		}
		if(GetItem.gameObject.GetComponent<player_control>().NewItemType == 4)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Item_Name + " \n " +
					"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.HP  + " \n " +
					"Defence : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Defence  + " \n " +
					"Damage : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Damage  + " \n " +
					"Cri : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Cri  + " \n " +
					"HP : " + DropItem.gameObject.GetComponent<DropItem>().m_item.HP_Regen  + " \n " +
					"Barrier : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Barrier  + " \n " +
					"Potion_up : " + DropItem.gameObject.GetComponent<DropItem>().m_item.Potion_Up;
		}
	}
	// Update is called once per frame
	void Update() 
	{
		
	}
}
