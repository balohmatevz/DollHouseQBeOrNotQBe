using UnityEngine;
using System.Collections;

public class WC : Furniture {
    public override void onUpdateInteract(){
        playerUsingThis.statWaste += 8f * Time.deltaTime;
        playerUsingThis.statHealth -= 4f * Time.deltaTime;
        if (playerUsingThis.statWaste > 100.0f)
        {
            playerUsingThis.statWaste = 100.0f;
            playerUsingThis = null;
        }
    }
}
