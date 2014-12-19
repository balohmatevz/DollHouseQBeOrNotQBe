using UnityEngine;
using System.Collections;

public class Sink : Furniture {
    public override void onUpdateInteract(){
        playerUsingThis.statHealth += 1f * Time.deltaTime;
        if (playerUsingThis.statHealth > 100.0f)
        {
            playerUsingThis.statHealth = 100.0f;
            playerUsingThis = null;
        }
    }
}
