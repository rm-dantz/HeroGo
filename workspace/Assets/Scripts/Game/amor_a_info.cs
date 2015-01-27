using UnityEngine;
using System.Collections;

public class amor_a_info : ItemInterface
{
	//Item Detail Info
	int Grade;
	int Support_Option;
	int Special_Option;
	int Item_Level = 10;

	// Use this for initialization
	public amor_a_info()
	{
		Item_Type = 1;
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
				HP += Item_Level;
				Defence += Item_Level;
				break;
			}
			case 1: // UnCommon
			{
				HP += Item_Level;
				Defence += Item_Level;
				Support_Option = Random.Range (0, 5);
				SetSupportOption(Support_Option);
				break;
			}
			case 2: // Rare
			{
				HP += Item_Level;
				Defence += Item_Level;
				Special_Option = Random.Range (0, 5);
				SetSpecialOption(Special_Option);
				break;
			}
			case 3: // Legendary
			{
				HP += Item_Level;
				Defence += Item_Level;
				Support_Option = Random.Range (0, 5);
				SetSupportOption(Support_Option);
				Special_Option = Random.Range (0, 5);
				SetSpecialOption(Special_Option);
				break;
			}
		}
	}

	public void SetSupportOption(int SupportOptionLevel)
	{
		switch (SupportOptionLevel) 
		{
			case 0:
			{
					Damage += Item_Level;
					break;
			}
			case 1:
			{
					Cri += Item_Level;
					break;
			}
			case 2:
			{
					HP_Regen += Item_Level;
					break;
			}
			case 3:
			{
					Barrier += Item_Level;
					break;
			}
			case 4:
			{
					Potion_Up += Item_Level;
					break;
			}
		}
	}

	public void SetSpecialOption(int SpecialOptionLevel)
	{
		switch (SpecialOptionLevel) 
		{
			case 0:
			{
				
				break;
			}
			case 1:
			{
				
				break;
			}
			case 2:
			{
				
				break;
			}
			case 3:
			{
				
				break;
			}
			case 4:
			{
				
				break;
			}
		}
	}
}
	