using UnityEngine;
using System.Collections;

public class UIHelpText : MonoBehaviour {

    public string type = "";

	// Use this for initialization
	void Start () {
        GameController.uiHelpText.Add(this);
        if (this.guiTexture != null)
        {
            this.guiTexture.enabled = false;
        }
        if (this.renderer != null)
        {
            this.renderer.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
