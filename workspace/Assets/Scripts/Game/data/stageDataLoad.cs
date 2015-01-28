using UnityEngine;
using System;
using System.Collections;

public class stageDataLoad : CSVParser {

	string _baseFileName;
	ArrayList _stageDataMap = new ArrayList();

	
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
		Debug.Log (inputData [0]);
		tempData.stageID			= Convert.ToInt32( inputData[count++] );
		tempData.type				= Convert.ToInt32( inputData[count++] );
		tempData.itemLevel			= inputData[count++].Split('/');
		tempData.length				= Convert.ToInt32( inputData[count++] );
		tempData.obstacleRate  		= inputData[count++].Split('/');
		tempData.obstacleID			= Convert.ToInt32( inputData[count++] );	
		tempData.treasureRate		= inputData[count++].Split('/');
		tempData.wandRate			= inputData[count++].Split('/');
		tempData.monsterRate    	= inputData[count++].Split('/');
		tempData.monsterMax    		= Convert.ToInt32( inputData [count++] ); 
		tempData.monsterLevel		= inputData[count++].Split('/');;
		tempData.monsterPool    	= inputData[count++].Split('/');
		tempData.resetWandType    	= Convert.ToInt32 (inputData [count++] );

		
		_stageDataMap.Add( tempData );
		
		
	}


	
	private stageData GetHeroData( int stageID )
	{
		foreach (stageData returnData in _stageDataMap) {
			if ( returnData.stageID == stageID )
				return returnData;
		}
		return null;
	}

}
