using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monitor : Furniture {

    Light screenLight;
    GameObject screen;
    int lightChangeTimer = 40;
    List<Color> screenColors = new List<Color>();
    
    public override void OnInteract(){
        if (screenColors.Count == 0)
        {
            screenColors.Add(Color.red);
            screenColors.Add(Color.green);
            screenColors.Add(Color.blue);
        }

        foreach (Transform t in this.transform)
        {
            if(t.name == "ScreenLight"){
                screenLight = t.gameObject.GetComponent<Light>();
            }
            if(t.name == "Screen"){
                screen = t.gameObject;
            }
        }
        lightChangeTimer = 1;
	}

    
    public override void onUpdateInteract(){
        playerUsingThis.statFun += 6f * Time.deltaTime;
        if (playerUsingThis.statFun > 100.0f)
        {
            playerUsingThis.statFun = 100.0f;
            playerUsingThis = null;
        }
        lightChangeTimer--;
        if (lightChangeTimer == 0)
        {
            lightChangeTimer = Random.Range(3,6)*10;
            int newcolor = Random.Range(0, screenColors.Count);
            screen.renderer.material.color = screenColors[newcolor];
            screenLight.color = screenColors[newcolor];
        }
    }
}
