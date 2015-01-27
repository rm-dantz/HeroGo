using UnityEngine;
using System.Collections;

public class amor_c_info : ItemInterface
{
	//Item Detail Info
	public int Grade;
	
	// Use this for initialization
	public amor_c_info()
	{
		Item_Type = 3;
		Item_Name = "normal";
		HP = 25f;
		Defence = 1f;
		MagicDefence = 1f;
		Damage = 0;
		Cri = 0;
		HP_Regen = 0;
		Barrier = 0;
		Potion_Up = 0;
		
		Debug.Log 
			(
				"ItemName : " + Item_Name + " / " +
				"HP : " + HP + " / " +
				"Defence" + Defence + " / " +
				"Damage : " + Damage + " / " +
				"Cri : " + Cri + " / " +
				"HP : " + HP_Regen + " / " +
				"Barrier : " + Barrier + " / " +
				"Potion_up : " + Potion_Up + " / "
				);
	}
	
	public override void replace()
	{
		Grade = Random.Range (0, 4);
		
		switch (Grade) 
		{
		case 0: // Common
		{
			
			break;
		}
		case 1: // UnCommon
		{
			
			break;
		}
		case 2: // Rare
		{
			
			break;
		}
		case 3: // Legendary
		{
			
			break;
		}
		}
	}
}
