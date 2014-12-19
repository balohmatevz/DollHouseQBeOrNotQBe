using UnityEngine;
using System.Collections;

public class Bathtub : Furniture {
    public override void onUpdateInteract(){
        playerUsingThis.statHealth += 4f * Time.deltaTime;
        if (playerUsingThis.statHealth > 100.0f)
        {
            playerUsingThis.statHealth = 100f;
            playerUsingThis = null;
        }
    }
}
