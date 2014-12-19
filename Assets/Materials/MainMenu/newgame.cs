using UnityEngine;
using System.Collections;

public class newgame : MonoBehaviour {
    
    void OnMouseDown(){
        MainMenuGameController.startGame = true;
        MainMenuGameController.mainMenuSleep.particleSystem.Stop();
    }
}
