using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	public UISlider _slider;
	public float MaxHP = 100;
	public float CurrentHP = 25;
	// Use this for initialization
	public static VitalBar instance;
	void Awake()
	{
		_slider = GetComponent<UISlider> ();
		if(_slider == null)
		{
			Debug.Log ("Could not find the UISlider");
			return;
		}
		instance = this;
	}

	public void UpdateDisplay(float MaxHP, float CurrentHP)
	{
		_slider.value = CurrentHP / MaxHP;
	}

	public static VitalBar getInstance(){
				return instance;
		}
}
