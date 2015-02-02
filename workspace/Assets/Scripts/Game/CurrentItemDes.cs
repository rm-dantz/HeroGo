using UnityEngine;
using System.Collections;

public class CurrentItemDes : MonoBehaviour {
	//Item Info 0 : cap, 1 : robe, 2 : shoes, 3 : cloack
	public GameObject GetItem;

	public void Init()
	{
		if(GetItem.gameObject.GetComponent<player_control>().ItemType == 1)
		{
			gameObject.GetComponent<UILabel> ().text = 
					"Name : " + GetItem.gameObject.GetComponent<player_control>().current_cap.Item_Name + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_cap.HP  + " \n " +
					"Defence : " + GetItem.gameObject.GetComponent<player_control>().current_cap.Defence  + " \n " +
					"Damage : " + GetItem.gameObject.GetComponent<player_control>().current_cap.Damage  + " \n " +
					"Cri : " + GetItem.gameObject.GetComponent<player_control>().current_cap.Cri  + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_cap.HP_Regen  + " \n " +
					"Barrier : " + GetItem.gameObject.GetComponent<player_control>().current_cap.Barrier  + " \n " +
					"Potion_up : " + GetItem.gameObject.GetComponent<player_control>().current_cap.Potion_Up;

		}
		if(GetItem.gameObject.GetComponent<player_control>().ItemType == 2)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + GetItem.gameObject.GetComponent<player_control>().current_robe.Item_Name + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_robe.HP  + " \n " +
					"Defence : " + GetItem.gameObject.GetComponent<player_control>().current_robe.Defence  + " \n " +
					"Damage : " + GetItem.gameObject.GetComponent<player_control>().current_robe.Damage  + " \n " +
					"Cri : " + GetItem.gameObject.GetComponent<player_control>().current_robe.Cri  + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_robe.HP_Regen  + " \n " +
					"Barrier : " + GetItem.gameObject.GetComponent<player_control>().current_robe.Barrier  + " \n " +
					"Potion_up : " + GetItem.gameObject.GetComponent<player_control>().current_robe.Potion_Up;
		}
		if(GetItem.gameObject.GetComponent<player_control>().ItemType == 3)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.Item_Name + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.HP  + " \n " +
					"Defence : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.Defence  + " \n " +
					"Damage : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.Damage  + " \n " +
					"Cri : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.Cri  + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.HP_Regen  + " \n " +
					"Barrier : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.Barrier  + " \n " +
					"Potion_up : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.Potion_Up;
		}
		if(GetItem.gameObject.GetComponent<player_control>().ItemType == 4)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.Item_Name + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.HP  + " \n " +
					"Defence : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.Defence  + " \n " +
					"Damage : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.Damage  + " \n " +
					"Cri : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.Cri  + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.HP_Regen  + " \n " +
					"Barrier : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.Barrier  + " \n " +
					"Potion_up : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.Potion_Up;
		}
	}
	// Update is called once per frame
	void Update() 
	{
		
	}
}
