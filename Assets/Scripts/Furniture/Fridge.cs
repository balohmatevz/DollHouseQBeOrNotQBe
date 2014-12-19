using UnityEngine;
using System.Collections;

public class Fridge : Furniture {
    public override void onUpdateInteract(){
        playerUsingThis.statHunger += 4f * Time.deltaTime;
        if (playerUsingThis.statHunger > 100.0f)
        {
            playerUsingThis.statHunger = 100.0f;
            playerUsingThis = null;
        }
    }
}
