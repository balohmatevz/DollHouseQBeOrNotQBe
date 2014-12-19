using UnityEngine;
using System.Collections;

public class PathfindingBall : MonoBehaviour {
	
	public int Floor = -1;
	public string RoomLeft = "";
	public string RoomRight = "";
	public string StairwayDir = "";

	// Use this for initialization
	void Start () {
		GameController.PathfindingBalls.Add (this);
        this.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
