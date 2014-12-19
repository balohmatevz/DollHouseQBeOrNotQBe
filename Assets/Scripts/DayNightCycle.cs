using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        this.light.intensity = (Mathf.Cos(GameController.dayNight)+1f) / 4.0f;
	}
}
