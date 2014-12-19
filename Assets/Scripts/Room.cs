using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

	public string roomID = "";
	public int floor = -1;
	public bool stairs = false;
	public string pathToStairs = "";
    public string roomName = "Unnamed room";

	// Use this for initialization
	void Start () {
		GameController.Rooms.Add (this);
	}
	
	// Update is called once per frame
	void Update () {
	
    }
    
    public void OnMouseEnter(){
        GameController.hoverHint.guiText.text = "Room: "+roomName;
    }
    public void OnMouseExit(){
        GameController.hoverHint.guiText.text = "";
    }
	
	List<PathfindingBall> getPathToStairs(PathfindingBall currentLocation){

		string nextRoomID = "";

		if (currentLocation.StairwayDir == "Left") {
			nextRoomID = currentLocation.RoomLeft;
		} else {
			nextRoomID = currentLocation.RoomRight;
		}

		Room nextRoom = GameController.getRoomFromID(nextRoomID);
		if(nextRoom.stairs){
			//We found the stairs, yay!
			List<PathfindingBall> result = new List<PathfindingBall>();
			result.Add (currentLocation);
			return result;
		}

		//We still have somt trecking to do to find the stairs!
		List<PathfindingBall> nextRoomPFBalls = GameController.getPathfindingBallsForRoom(nextRoom);
		foreach(PathfindingBall pfb in nextRoomPFBalls){
			if (pfb != currentLocation){
				List<PathfindingBall> result = getPathToStairs(pfb);
				result.Add(currentLocation);
				return result;
			}
		}

		Debug.Log ("Error in pathfinding - getPathToStairs()");
		return new List<PathfindingBall>();

	}
	
    public void MsDown(){
        OnMouseDown();
    }

	void OnMouseDown(){
		//Debug.Log ("CLICK!! :D "+roomID);
		
		if(GameController.SelectedPlayer == null){
			return;
		}

		if (GameController.SelectedPlayer.currentFloor != this.floor) {
			//Player is on a different floor, need to pathfind to the stairs.
			
			//Player -> Stairs
			List<PathfindingBall> playerPath = new List<PathfindingBall>();
			Room playerRoom = GameController.getRoomFromID(GameController.SelectedPlayer.currentRoom);
			List<PathfindingBall> playerRoomsPFBalls = GameController.getPathfindingBallsForRoom(playerRoom);
			foreach(PathfindingBall pfb in playerRoomsPFBalls){
				if(playerRoom.pathToStairs == "Left"){
					if(pfb.StairwayDir == "Left"){
						List<PathfindingBall> path = getPathToStairs(pfb);
						if(playerPath.Count == 0){
							//Set the path if none exists.
							playerPath = path;
						}else if(playerPath.Count > path.Count){
							//Apply shorter path
							playerPath = path;
						}
					}
				}
				if(playerRoom.pathToStairs == "Right"){
					if(pfb.StairwayDir == "Right"){
						List<PathfindingBall> path = getPathToStairs(pfb);
						if(playerPath.Count == 0){
							//Set the path if none exists.
							playerPath = path;
						}else if(playerPath.Count > path.Count){
							//Apply shorter path
							playerPath = path;
						}
					}
				}
			}
			
			//Stairs -> Target
			List<PathfindingBall> targetPath = new List<PathfindingBall>();
			List<PathfindingBall> thisRoomsPFBalls = GameController.getPathfindingBallsForRoom(this);
			foreach(PathfindingBall pfb in thisRoomsPFBalls){
				if(this.pathToStairs == "Left"){
					if(pfb.StairwayDir == "Left"){
						List<PathfindingBall> path = getPathToStairs(pfb);
						if(targetPath.Count == 0){
							//Set the path if none exists.
							targetPath = path;
						}else if(targetPath.Count > path.Count){
							//Apply shorter path
							targetPath = path;
						}
					}
				}
				if(this.pathToStairs == "Right"){
					if(pfb.StairwayDir == "Right"){
						List<PathfindingBall> path = getPathToStairs(pfb);
						if(targetPath.Count == 0){
							//Set the path if none exists.
							targetPath = path;
						}else if(targetPath.Count > path.Count){
							//Apply shorter path
							targetPath = path;
						}
					}
				}
			}

			playerPath.Reverse();

			List<PathfindingBall> CompletePath = new List<PathfindingBall>();
			CompletePath.AddRange(playerPath);



			CompletePath.AddRange(targetPath);

			GameController.SelectedPlayer.path = CompletePath;

			foreach(PathfindingBall pfbs in playerPath){
				pfbs.renderer.material.color = Color.cyan;
			}
			//Debug.Log ("PLAYER: PATH : "+playerPath.Count);
			
			
			
			foreach(PathfindingBall pfbs in targetPath){
				pfbs.renderer.material.color = Color.yellow;
			}
			//Debug.Log ("TARGET PATH : "+targetPath.Count);

		}else{
			
			Room playerRoom = GameController.getRoomFromID(GameController.SelectedPlayer.currentRoom);
			List<PathfindingBall> playerRoomPFBalls = GameController.getPathfindingBallsForRoom(playerRoom);
			foreach(PathfindingBall pfbs in playerRoomPFBalls){
				if(GameController.SelectedPlayer.currentRoom == pfbs.RoomLeft){
					//Moving to the right
                    List<PathfindingBall> path = getPathOnSameFloor(pfbs, this, "Right");
                    if(path != null){
                        path.Reverse();
                        //Debug.Log ("SAME FLOOR PATH RIGHT : "+path.Count);
                        GameController.SelectedPlayer.path = path;
                    }
				}else{
                    //Moving to the left
                    List<PathfindingBall> path = getPathOnSameFloor(pfbs, this, "Left");
                    if(path != null){
                        path.Reverse();
                        //Debug.Log ("SAME FLOOR PATH LEFT : "+path.Count);
                        GameController.SelectedPlayer.path = path;
                    }
				}
				//pfbs.renderer.material.color = Color.cyan;
			}
		}
	}

	List<PathfindingBall> getPathOnSameFloor(PathfindingBall current, Room target, string direction){
        
        if (direction == "Right")
        {
            if(current.RoomRight == target.roomID){
                List<PathfindingBall> result = new List<PathfindingBall> ();
                result.Add(current);
                return result;
            }
            if(current.RoomRight == ""){
                return null;
            }
        }
        if (direction == "Left")
        {
            if(current.RoomLeft == target.roomID){
                List<PathfindingBall> result = new List<PathfindingBall> ();
                result.Add(current);
                return result;
            }
            if(current.RoomLeft == ""){
                return null;
            }
        }

        if (direction == "Right") {
            string nextRoomID = current.RoomRight;
            Room nextRoom = GameController.getRoomFromID(nextRoomID);
            List<PathfindingBall> nextRoomPFBalls = GameController.getPathfindingBallsForRoom(nextRoom);
            foreach(PathfindingBall pfbs in nextRoomPFBalls){
                if(nextRoomID == pfbs.RoomLeft){
                    //Moving right
                    List<PathfindingBall> result = getPathOnSameFloor(pfbs, target, direction);
                    if(result != null){
                        result.Add(current);
                    }
                    return result;
                }
            }
            //Debug.Log("Something's gone wrong in getPathOnSameFloor() - right");
            return null;
        }
        
        if (direction == "Left") {
            string nextRoomID = current.RoomLeft;
            Room nextRoom = GameController.getRoomFromID(nextRoomID);
            List<PathfindingBall> nextRoomPFBalls = GameController.getPathfindingBallsForRoom(nextRoom);
            foreach(PathfindingBall pfbs in nextRoomPFBalls){
                if(nextRoomID == pfbs.RoomRight){
                    //Moving left
                    List<PathfindingBall> result = getPathOnSameFloor(pfbs, target, direction);
                    if(result != null){
                        result.Add(current);
                    }
                    return result;
                }
            }
            //Debug.Log("Something's gone wrong in getPathOnSameFloor() - left");
            return null;
        }

		return null;
	}
}
