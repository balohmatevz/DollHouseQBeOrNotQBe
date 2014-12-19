using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public int currentFloor = 0;
	public string currentRoom = "RoomBoiler";
	public List<PathfindingBall> path = new List<PathfindingBall>();
	public float movementSpeed = 0.4f;
	public bool usingStairs = false;
	public int nextStairState = -1;
	public int stairMovingFromFloor = -1;
    public int stairMovingToFloor = -1;
    public Furniture targetObject;
    public PathfindingBallFurniture targetObjectPFBall;

    public string playerName = "Unnamed player";

    public float statSleep = 100.0f;
    public float statCuriosity = 25.0f;
    public float statFun = 100.0f;
    public float statHealth = 50.0f;
    public float statWaste = 50.0f;
    public float statHunger = 50.0f;

    public Furniture usingObject;

	// Use this for initialization
	void Start () {
		GameController.Players.Add (this);
    }
    
    public void OnMouseEnter(){
        GameController.hoverHint.guiText.text = "Player: "+playerName;
    }
    public void OnMouseExit(){
        GameController.hoverHint.guiText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        
        statSleep -= 0.5f * Time.deltaTime;
        statCuriosity -= 0.5f * Time.deltaTime;
        statFun -= 0.5f * Time.deltaTime;
        statHealth -= 0.5f * Time.deltaTime;
        statWaste -= 0.5f * Time.deltaTime;
        statHunger -= 0.5f * Time.deltaTime;
        
        statSleep = Mathf.Clamp(statSleep, 0f, 100f);
        statCuriosity = Mathf.Clamp(statCuriosity, 0f, 100f);
        statFun = Mathf.Clamp(statFun, 0f, 100f);
        statHealth = Mathf.Clamp(statHealth, 0f, 100f);
        statWaste = Mathf.Clamp(statWaste, 0f, 100f);
        statHunger = Mathf.Clamp(statHunger, 0f, 100f);

		if (usingStairs) {
            usingObject = null;
			//Debug.Log("STAIRSTAIRSTAIR: "+stairMovingFromFloor+" -> "+stairMovingToFloor+" at stage "+nextStairState);
			PathfindingBallStairs nextBall;
			if(stairMovingFromFloor > stairMovingToFloor){
				//going down
				nextBall = GameController.getStairFromFloorsAndStage(stairMovingToFloor, stairMovingFromFloor, nextStairState);
			}else{
				//going up
				nextBall = GameController.getStairFromFloorsAndStage(stairMovingFromFloor, stairMovingToFloor, nextStairState);
			}
			this.transform.position = Vector3.MoveTowards(this.transform.position, nextBall.transform.position, movementSpeed);
			this.transform.LookAt(nextBall.transform);
			Vector3 v = this.transform.localRotation.eulerAngles;
			v.x = 0;
			this.transform.localRotation = Quaternion.Euler(v);

			if(Vector3.Distance(this.transform.position, nextBall.transform.position) < movementSpeed){
				if(stairMovingFromFloor > stairMovingToFloor){
					//going down
					nextStairState--;
				}else{
					//going up
					nextStairState++;
				}
				if(nextStairState == 0){
					currentFloor--;
					usingStairs = false;
				}else if(nextStairState == 5){
					currentFloor++;
					usingStairs = false;
				}
			}
			return;
		}

        if (path.Count > 0) {
			PathfindingBall pfb = path[0];
			if(Vector3.Distance(this.transform.position, pfb.transform.position) < movementSpeed){
				if(pfb.RoomLeft != this.currentRoom){
					this.currentRoom = pfb.RoomLeft;
				}
				if(pfb.RoomRight != this.currentRoom){
					this.currentRoom = pfb.RoomRight;
				}
				path.RemoveAt(0);
				if (path.Count == 0) {
					return;
				}
			}

            pfb = path[0];
            usingObject = null;
			if(pfb.Floor == this.currentFloor){
				//Move normally
				this.transform.position = Vector3.MoveTowards(this.transform.position, pfb.transform.position, movementSpeed);

				this.transform.LookAt(pfb.transform);
				Vector3 v = this.transform.localRotation.eulerAngles;
				v.x = 0;
				this.transform.localRotation = Quaternion.Euler(v);
			}else{
				//Stairs
				usingStairs = true;
				stairMovingFromFloor = this.currentFloor;
				if(pfb.Floor > this.currentFloor){
					//Moving up
					stairMovingToFloor = this.currentFloor + 1;
					nextStairState = 1;
				}else{
					//Moving down
					stairMovingToFloor = this.currentFloor - 1;
					nextStairState = 4;
				}
			}
        }else if(targetObjectPFBall != null){
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetObjectPFBall.transform.position, movementSpeed);

            this.transform.LookAt(targetObjectPFBall.transform);
            Vector3 v = this.transform.localRotation.eulerAngles;
            v.x = 0;
            this.transform.localRotation = Quaternion.Euler(v);

            if(Vector3.Distance(this.transform.position, targetObjectPFBall.transform.position) < movementSpeed){
                targetObjectPFBall = null;
                this.transform.LookAt(targetObject.transform);
                v = this.transform.localRotation.eulerAngles;
                v.x = 0;
                this.transform.localRotation = Quaternion.Euler(v);
                targetObject.Interact(this);
                targetObject = null;
                Debug.Log("ARRIVED YAY");
            }
        }
	}

	void OnMouseDown(){
		GameController.SelectedPlayer = this;
	}
}
