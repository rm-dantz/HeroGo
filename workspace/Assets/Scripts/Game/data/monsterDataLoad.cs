using UnityEngine;
using System;
using System.Collections;

public class monsterDataLoad : CSVParser {


	string _baseFileName;
	ArrayList _monsterDataMap = new ArrayList();
	
	public monsterDataLoad () {
		_baseFileName = "data/monster_data";
		Debug.Log( _baseFileName );
	}

	public override void Load()
	{
		_monsterDataMap.Add (new monsterData ());
		LoadFile( _baseFileName );
	}
	
	public int monsterNum () {
		return _monsterDataMap.Count;
	}


	public override void Parse( string[] inputData )
	{
		
		int count = 0;
		monsterData tempData = new monsterData();
		Debug.Log (inputData [0]);
		tempData.name	 			= inputData[count++];
		tempData.ID	 	 			= Convert.ToInt32( inputData[count++] );
		tempData.type	 			= Convert.ToInt32( inputData[count++] );
		tempData.element	 		= Convert.ToInt32( inputData[count++] );
		tempData.HP 				= Convert.ToInt32( inputData[count++] );
		tempData.physAtk 			= Convert.ToInt32( inputData[count++] );
		tempData.magicAtk 		    = Convert.ToInt32( inputData[count++] );
		tempData.moveSpd 		    = (float)Convert.ToDouble( inputData [count++] ); 
		tempData.atkSpd 			= (float)Convert.ToDouble( inputData [count++] );
		tempData.shotSize 		    = (float)Convert.ToDouble( inputData [count++] );
		tempData.shotSpd 		    = (float)Convert.ToDouble (inputData [count++] );
		tempData.flightPattern 		= Convert.ToInt32( inputData[count++] );
		tempData.gold 				= Convert.ToInt32( inputData[count++] );
		tempData.height 			= Convert.ToInt32( inputData[count++] );
		tempData.length 			= Convert.ToInt32( inputData[count++] );
		

		_monsterDataMap.Add( tempData );


	}

	private monsterData GetMonsterData( int monsterID )
	{
		foreach (monsterData returnData in _monsterDataMap) {
			if ( returnData.ID == monsterID )
				return returnData;
		}
		return null;
	}
	
	public monsterData CreateMonster( int monsID )
	{
		monsterData data = GetMonsterData (monsID);
		return data;
	}

}
