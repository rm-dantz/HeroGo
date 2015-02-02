using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class CSVParser
{
	public CSVParser()
	{
	}
	~CSVParser()
	{
		_Header  = null;
	}
	
	protected string[] _Header  = null;
	
	// Must Override!
	public virtual void Load() {}
	public virtual void Parse( string[] inputData ) { }
	
	// Getter / Setter
	// Default Functions
	public void LoadFile( string filePath )
	{
		string fileFullPath = filePath;
		TextAsset bindata= Resources.Load(fileFullPath) as TextAsset;
		
		if( bindata == null )
		{
			Debug.LogError( "File not found or not readable : " + fileFullPath );
			return;
		}
		
		int lineCount = 0;
		//		bindata.tebindata
		string[] inputData = bindata.text.Split ('\n');
		for ( int i=0; i<inputData.Length; i++ )
		{
			string[] stringList = inputData[i].Split( ',' );
			if( stringList.Length == 0 )
			{
				continue;
			}
			
			if( ParseData( stringList, lineCount ) == false )
			{
				Debug.LogError( "Parsing fail : " + stringList.ToString() );
			}
		}
	}
	public bool ParseData( string[] inputData, int lineCount )
	{
		//		if( lineCount == 0 )
		//		{
		//			// Header
		//			_Header = inputData;
		//			return true;
		//		}
		if( VarifyKey( inputData[0] ) == false )
		{
			//Debug.Log( "VarifyKey fail : " + inputData[0] );
			return false;
		}
		
		Parse( inputData );
		return true;
	}
	public virtual bool VarifyKey( string keyValue )
	{
		
		return true;
	}
	
	public string ReplaceAll(string input, char target, char change)
	{
		
		char[] dashes = new char[input.Length];
		for(int i=0; i<dashes.Length; i++){
			dashes[i] = (input[i] == target) ? change:input[i];
			//or dashes[i] = ' '; for every character
		}
		
		return new string(dashes);
	}
	
}