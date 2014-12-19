using UnityEngine;
using System.Collections;

public class PathfindingBallStairs : MonoBehaviour {
	
	public int lowerFloor = -1;
	public int higherFloor = -1;
	public int stage = -1; //four stages, 1 = lower floor, 4 = upper floor

	// Use this for initialization
	void Start () {
        GameController.PathfindingBallsStairs.Add (this);
        this.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
