using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
	
	[SerializeField] private float fillAmount;

	[SerializeField] private Image healthBarValue;

	// calculates your current hp as a value between 0 and 1;
	private float mapHP(float value, float inMin, float inMax, float outMin, float outMax) {
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}

	private void ManageBar() {
		healthBarValue.fillAmount = mapHP(GameManager.instance.HP, 0f, 100f, 0f , 1f);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		ManageBar ();
		
	}
}
