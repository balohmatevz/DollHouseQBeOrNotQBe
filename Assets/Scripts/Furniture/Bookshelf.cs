using UnityEngine;
using System.Collections;

public class Bookshelf : Furniture {
    
    public override void onUpdateInteract(){
        //Debug.Log("Bed : BED");
        playerUsingThis.statCuriosity += 5f * Time.deltaTime;
        playerUsingThis.statSleep -= 2f * Time.deltaTime;
        playerUsingThis.statFun += 1f * Time.deltaTime;
        if (playerUsingThis.statFun > 100.0f)
        {
            playerUsingThis.statFun = 100.0f;
        }
        if (playerUsingThis.statCuriosity > 100.0f)
        {
            playerUsingThis.statCuriosity = 100.0f;
            playerUsingThis = null;
        }
    }
    
    public override void OnInteract(){

    }
}
