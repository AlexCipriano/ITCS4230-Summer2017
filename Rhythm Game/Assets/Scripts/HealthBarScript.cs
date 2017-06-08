using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
	
	[SerializeField] private float fillAmount;
	[SerializeField] private float lerpSpeed;
	[SerializeField] private Image healthBarValue;

	// calculates your current hp as a value between 0 and 1;
	private float mapHP(float value, float inMin, float inMax, float outMin, float outMax) {
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}

	private void ManageBar() {
		//if (fillAmount != healthBarValue.fillAmount)
		healthBarValue.fillAmount = Mathf.Lerp(healthBarValue.fillAmount, mapHP(GameManager.instance.HP, 0f, 100f, 0f , 1f), Time.deltaTime * lerpSpeed);
	}

	// Use this for initialization
	void Start () {
		lerpSpeed = 5f;
		fillAmount = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		ManageBar();
	}
}
