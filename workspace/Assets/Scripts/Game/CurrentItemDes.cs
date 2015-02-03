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
					"Name : " + GetItem.gameObject.GetComponent<player_control>().current_cap.name + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_cap.armorHP  + " \n " +
					"Defence : " + GetItem.gameObject.GetComponent<player_control>().current_cap.def  + " \n " +
					"Damage : " + GetItem.gameObject.GetComponent<player_control>().current_cap.mAtk  + " \n " +
					"Cri : " + GetItem.gameObject.GetComponent<player_control>().current_cap.critChance  + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_cap.hpRegen  + " \n " +
					"Barrier : " + GetItem.gameObject.GetComponent<player_control>().current_cap.shield  + " \n " +
					"Potion_up : " + GetItem.gameObject.GetComponent<player_control>().current_cap.potionup;

		}
		if(GetItem.gameObject.GetComponent<player_control>().ItemType == 2)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + GetItem.gameObject.GetComponent<player_control>().current_robe.name + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_robe.armorHP  + " \n " +
					"Defence : " + GetItem.gameObject.GetComponent<player_control>().current_robe.def  + " \n " +
					"Damage : " + GetItem.gameObject.GetComponent<player_control>().current_robe.mAtk  + " \n " +
					"Cri : " + GetItem.gameObject.GetComponent<player_control>().current_robe.critChance  + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_robe.hpRegen  + " \n " +
					"Barrier : " + GetItem.gameObject.GetComponent<player_control>().current_robe.shield  + " \n " +
					"Potion_up : " + GetItem.gameObject.GetComponent<player_control>().current_robe.potionup;
		}
		if(GetItem.gameObject.GetComponent<player_control>().ItemType == 3)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.name + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.armorHP  + " \n " +
					"Defence : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.def  + " \n " +
					"Damage : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.mAtk  + " \n " +
					"Cri : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.critChance  + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.hpRegen  + " \n " +
					"Barrier : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.shield  + " \n " +
					"Potion_up : " + GetItem.gameObject.GetComponent<player_control>().current_shoes.potionup;
		}
		if(GetItem.gameObject.GetComponent<player_control>().ItemType == 4)
		{
			gameObject.GetComponent<UILabel> ().text = 
				"Name : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.name + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.armorHP  + " \n " +
					"Defence : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.def  + " \n " +
					"Damage : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.mAtk  + " \n " +
					"Cri : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.critChance  + " \n " +
					"HP : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.hpRegen  + " \n " +
					"Barrier : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.shield  + " \n " +
					"Potion_up : " + GetItem.gameObject.GetComponent<player_control>().current_cloack.potionup;
		}
	}
	// Update is called once per frame
	void Update() 
	{
		
	}
}
