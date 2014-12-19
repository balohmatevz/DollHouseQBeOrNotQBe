using UnityEngine;
using System.Collections;

public class HoveredOverHint : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameController.hoverHint = this;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
