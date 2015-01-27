using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour 
{
	public player_control m_objPlayer;	
	public Enemy_Creator m_enemy_cr;
	void Awake() {
	
	}
	
	// Update is called once per frame
	void Update() {

	}

	public void OnClickStart()
	{
		m_objPlayer.Jump ();
	}

	public void ClickRegen()
	{
		m_enemy_cr.Regen ();
	}
}
