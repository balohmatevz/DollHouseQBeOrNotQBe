using UnityEngine;
using System.Collections;

public class Furniture : MonoBehaviour {

    public string objectID = "";
    public string roomID = "";
    public Player playerUsingThis;
    public string objectName = "Unnamed";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerUsingThis != null)
        {   
            if(playerUsingThis.usingObject != this){
                //Debug.Log("Player STOPPED using me D: /crycrycrycrycry");
                playerUsingThis = null;
            }else{
                //Debug.Log("Player is using me! :D");
                onUpdateInteract();
            }
        }
    }

    public virtual void onUpdateInteract(){

    }

    public void OnMouseEnter(){
        GameController.hoverHint.guiText.text = objectName;
    }
    public void OnMouseExit(){
        GameController.hoverHint.guiText.text = "";
    }

    public void Interact(Player p){
        Debug.Log("Furniture : Interact");
        playerUsingThis = p;
        p.usingObject = this;
        OnInteract();
    }

    public virtual void OnInteract(){
        Debug.Log("Furniture : OnInteract");
    }
    
    void OnMouseDown(){
        Debug.Log ("CLICK!! :D "+objectID);
        
        if(GameController.SelectedPlayer == null){
            return;
        }

        Room room = GameController.getRoomFromID(roomID);
        room.MsDown();


        PathfindingBallFurniture pfbf = GameController.getFurniturePFBall(objectID);
        
        GameController.SelectedPlayer.targetObject = this;
        GameController.SelectedPlayer.targetObjectPFBall = pfbf;

    }
}
