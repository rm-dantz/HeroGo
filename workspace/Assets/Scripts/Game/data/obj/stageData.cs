using UnityEngine;
using System.Collections;

public class stageData : MonoBehaviour {

	public stageData(){

	}

	public int 			stageID;
	public int 			type;
	public string[] 	itemLevel;
	public int			length;
	public string[] 	obstacleRate;
	public int 			obstacleID;
	public string[] 	treasureRate;
	public string[] 	wandRate;
	public string[] 	monsterRate;
	public int 			monsterMax;
	public string[] 	monsterLevel;
	public string[] 	monsterPool;
	public int 			resetWandType;

	public stageData(stageData _stage){
		stageID 		=_stage.stageID;
		type 			=_stage.type;
		itemLevel 		=_stage.itemLevel;
		length 			=_stage.length;
		obstacleRate 	=_stage.obstacleRate;
		obstacleID 		=_stage.obstacleID;
		treasureRate 	=_stage.treasureRate;
		wandRate 		=_stage.wandRate;
		monsterRate 	=_stage.monsterRate;
		monsterMax 		=_stage.monsterMax;
		monsterLevel 	=_stage.monsterLevel;
		monsterPool 	=_stage.monsterPool;
		resetWandType 	=_stage.resetWandType;
	}


	~stageData(){

	}
}
