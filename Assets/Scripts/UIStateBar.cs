using UnityEngine;
using System.Collections;

public class UIStateBar : MonoBehaviour {

    public string state = "";

	// Use this for initialization
	void Start () {
	    switch(state){
            case "SLEEP":
                GameController.stateBarSleep = this;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameController.SelectedPlayer == null)
        {
            this.guiTexture.enabled = false;
            return;
        } else
        {
            this.guiTexture.enabled = true;
        }

        float coef = 0.0f;
        float val = 0.0f;
        switch(state){
            case "SLEEP":
                val = GameController.SelectedPlayer.statSleep;
                coef = val / 100.0f;
                break;
            case "FUN":
                val = GameController.SelectedPlayer.statFun;
                coef = val / 100.0f;
                break;
            case "CURIOSITY":
                val = GameController.SelectedPlayer.statCuriosity;
                coef = val / 100.0f;
                break;
            case "HEALTH":
                val = GameController.SelectedPlayer.statHealth;
                coef = val / 100.0f;
                break;
            case "WASTE":
                val = GameController.SelectedPlayer.statWaste;
                coef = val / 100.0f;
                break;
            case "HUNGER":
                val = GameController.SelectedPlayer.statHunger;
                coef = val / 100.0f;
                break;
            default:
                return;
                break;
        }

        //Debug.Log("STAT = "+coef);
        this.guiTexture.color = Color.Lerp(new Color(0.5f, 0, 0), new Color(0, 0.3f, 0), coef);
        Rect r = this.guiTexture.pixelInset;
        r.width = val + 10;
        this.guiTexture.pixelInset = r;
	}
}
