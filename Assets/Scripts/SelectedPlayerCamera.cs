using UnityEngine;
using System.Collections;

public class SelectedPlayerCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameController.PlayerCam = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.SelectedPlayer != null) {
			this.camera.enabled = true;
			Vector3 vEnd = GameController.SelectedPlayer.transform.position + (GameController.SelectedPlayer.transform.forward.normalized * 0.5f);
			this.transform.position = vEnd;
			this.transform.LookAt (GameController.SelectedPlayer.transform);
			vEnd.y += 0.5f;
			this.transform.position = vEnd;
		} else {
			this.camera.enabled = false;
		}
	}
}
