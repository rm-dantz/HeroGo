using UnityEngine;
using System;
using System.Collections;

public class stageDataLoad : CSVParser {

	string _baseFileName;
	public ArrayList _stageDataMap = new ArrayList();

	
	public stageDataLoad () {
		_baseFileName = "data/stage_data";
		Debug.Log( _baseFileName );
	}
	
	public override void Load()
	{
		_stageDataMap.Add (new stageData ());
		LoadFile( _baseFileName );
	}
	
	public int stageNum () {
		return _stageDataMap.Count;
	}

	
	public override void Parse( string[] inputData )
	{
		
		int count = 0;
		stageData tempData = new stageData();

		tempData.stageID			= Convert.ToInt32( inputData[count++] );
		tempData.type				= Convert.ToInt32( inputData[count++] );
		tempData.length				= Convert.ToInt32( inputData[count++] );
		tempData.obstacleRate		= inputData[count++].Split('/');
		tempData.obstacleID			= inputData[count++].Split('/');
		tempData.treasureRate		= inputData[count++].Split('/');
		tempData.treasureID			= inputData[count++].Split('/');
		tempData.armorMinLvl		= Convert.ToInt32( inputData[count++] );
		tempData.armorLvlRate		= inputData[count++].Split('/');
		tempData.armorGradeDropRate = inputData[count++].Split('/');
		tempData.wandRate			= inputData[count++].Split('/');
		tempData.monsterList		= inputData[count++].Split('/');
		tempData.monsterLevel		= inputData[count++].Split('/');
		tempData.monsterMax 		= Convert.ToInt32 (inputData [count++]);
		tempData.monsterRate		= inputData[count++].Split('/');
		tempData.namedMonster		= Convert.ToInt32 (inputData [count++]);
		tempData.enchant			= Convert.ToInt32 (inputData [count++]);
		tempData.resetWandType		= Convert.ToInt32 (inputData [count++]);
		
		_stageDataMap.Add( tempData );
	}


	
	public stageData GetStageData( int stageID )
	{
		foreach (stageData returnData in _stageDataMap) {
			if ( returnData.stageID == stageID )
				return returnData;
		}
		return null;
	}

}
