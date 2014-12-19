using UnityEngine;
using System.Collections;

public class PathfindingBallFurniture : MonoBehaviour {
    
    public string RoomID = "";
    public string ObjectID = "";

	// Use this for initialization
	void Start () {
        GameController.PathfindingBallsFurniture.Add(this);
        this.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
