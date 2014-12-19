using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuGameController : MonoBehaviour {

    public static bool startGame = false;
    public static int startGameProgress = 0;
    public static MainMenuSleep mainMenuSleep;
    public static List<MainMenuEyes> mainMenuEyes = new List<MainMenuEyes>();
	
	// Update is called once per frame
	void Update () {
        if(startGame){
            startGameProgress++;
            if(startGameProgress == 100){
                Application.LoadLevel ("scene");
            }
            Color skinColor = new Color((207f/255), (193f/255), (142f/255));
            float f = startGameProgress / 20f;
            if(startGameProgress > 60 && startGameProgress < 70){
                f = 0; //BLINK
            }
            Color eyeColor = Color.Lerp(skinColor, Color.black, Mathf.Min(1.0f, f));
            foreach(MainMenuEyes eye in mainMenuEyes){
                eye.renderer.material.color = eyeColor;
            }
        }
	}
}
