using UnityEngine;
using System.Collections;

public class stageData  {

	public stageData(){

	}

	public int 			stageID;
	public int 			type;
	public int			length;
	public string[] 	obstacleRate;
	public string[] 	obstacleID;

	public string[] 	treasureRate;
	public string[]		treasureID;
	public int			armorMinLvl;
	public string[]		armorLvlRate;
	public string[]		armorGradeDropRate;

	public string[] 	wandRate;

	public string[] 	monsterList;
	public string[] 	monsterLevel;
	public int 			monsterMax;
	public string[] 	monsterRate;

	public int			namedMonster;
	public int			enchant;

	public int 			resetWandType;

	public stageData(stageData _stage){

		stageID 					= _stage.stageID;
		type						= _stage.type;
		length						= _stage.length;	

		obstacleRate				= _stage.obstacleRate;
		obstacleID					= _stage.obstacleID;

		treasureRate				= _stage.treasureRate;
		treasureID					= _stage.treasureID;
		armorMinLvl					= _stage.armorMinLvl;
		armorLvlRate				= _stage.armorLvlRate;
		armorGradeDropRate			= _stage.armorGradeDropRate;

		wandRate 					= _stage.wandRate;

		monsterList					= _stage.monsterList;
		monsterLevel				= _stage.monsterLevel;
		monsterMax					= _stage.monsterMax;
		monsterRate					= _stage.monsterRate;

		namedMonster				= _stage.namedMonster;
		enchant						= _stage.enchant;

		resetWandType				= _stage.resetWandType;




	}


	~stageData(){

	}
}
