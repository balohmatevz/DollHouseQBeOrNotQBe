using UnityEngine;
using System.Collections;

public class Bed : Furniture {
    
    public override void onUpdateInteract(){
        //Debug.Log("Bed : BED");
        playerUsingThis.statSleep += 8f * Time.deltaTime;
        if (playerUsingThis.statSleep > 100.0f)
        {
            playerUsingThis.statSleep = 100.0f;
            playerUsingThis = null;
        }
    }

    public override void OnInteract(){

    }
}
