using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        int time = (int)(Mathf.Floor((GameController.dayNight / (2 * Mathf.PI)) * 24)) + 12;
        if (time >= 24)
        {
            time -= 12;
        }

        if (time < 10)
        {
            this.guiText.text = "Time: 0" + time + ":00";
        } else
        {
            this.guiText.text = "Time: " + time + ":00";
        }



	}
}
