using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static List<Player> Players = new List<Player>();
	public static Player SelectedPlayer = null;
	public static SelectedPlayerCamera PlayerCam = null;
	
	public static List<PathfindingBall> PathfindingBalls = new List<PathfindingBall>();
    public static List<Room> Rooms = new List<Room>();
    public static List<PathfindingBallStairs> PathfindingBallsStairs = new List<PathfindingBallStairs>();
    public static List<PathfindingBallFurniture> PathfindingBallsFurniture = new List<PathfindingBallFurniture>();

    public static List<UIHelpText> uiHelpText = new List<UIHelpText>();
    public bool helpTextOver = false;
    public int helpTextTick = 0;

    public static UIStateBar stateBarSleep;

    public static HoveredOverHint hoverHint;
    public static float dayNight = 0f;

	public static Dictionary<string, List<PathfindingBallStairs>> stairTransitionPaths = new Dictionary<string, List<PathfindingBallStairs>> ();

	bool initialized = false;
	int initCountdown = 60;

	// Use this for initialization
	void Start () {
		this.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {

        dayNight += 0.001f;
        if (dayNight > (2*Mathf.PI))
        {
            dayNight = 0f;
        }

        if (!helpTextOver)
        {
            helpTextTick++;
            if(helpTextTick == 60){
                foreach(UIHelpText ht in uiHelpText){
                    if(ht.type == "ZOOM"){
                        ht.guiTexture.enabled = true;
                    }
                }
            }
            if(helpTextTick == 360){
                foreach(UIHelpText ht in uiHelpText){
                    if(ht.type == "ZOOM"){
                        ht.guiTexture.enabled = false;
                    }
                }
            }
            if(helpTextTick == 400){
                foreach(UIHelpText ht in uiHelpText){
                    if(ht.type == "WASD"){
                        ht.guiTexture.enabled = true;
                    }
                }
            }
            if(helpTextTick == 600){
                foreach(UIHelpText ht in uiHelpText){
                    if(ht.type == "WASD"){
                        ht.guiTexture.enabled = false;
                    }
                }
            }
            if(helpTextTick == 640){
                foreach(UIHelpText ht in uiHelpText){
                    if(ht.type == "SELECTMOB"){
                        ht.renderer.enabled = true;
                    }
                }
            }
            if(helpTextTick == 940){
                foreach(UIHelpText ht in uiHelpText){
                    if(ht.type == "SELECTMOB"){
                        ht.renderer.enabled = false;
                    }
                }
            }
            if(helpTextTick == 980){
                foreach(UIHelpText ht in uiHelpText){
                    if(ht.type == "INTERACT"){
                        ht.guiTexture.enabled = true;
                    }
                }
            }
            if(helpTextTick == 1280){
                foreach(UIHelpText ht in uiHelpText){
                    if(ht.type == "INTERACT"){
                        ht.guiTexture.enabled = false;
                        helpTextOver = true;
                    }
                }
            }
        }

		if(!initialized){
			initCountdown -= 1;
			if(initCountdown == 0){
				initStairs();
				initialized = true;
				this.renderer.material.color = Color.white;
			}
		}
    }
    
    public static PathfindingBallStairs getStairFromFloorsAndStage(int lowerFloor, int higherFloor, int stage){
        foreach(PathfindingBallStairs pfbs in PathfindingBallsStairs){
            if(pfbs.lowerFloor == lowerFloor && pfbs.higherFloor == higherFloor && pfbs.stage == stage){
                return pfbs;
            }
        }
        return null;
    }
    
    public static PathfindingBallFurniture getFurniturePFBall(string objectID){
        foreach(PathfindingBallFurniture pfbf in PathfindingBallsFurniture){
            if(pfbf.ObjectID == objectID){
                return pfbf;
            }
        }
        return null;
    }

	void initStairs (){
		for (int from = 0; from <= 4; from++) {
			if(from > 0){
				//Going down
				int to = from -1;
				List<PathfindingBallStairs> stairPath = new List<PathfindingBallStairs>();
				for (int stage = 4; stage >= 1; stage--) {
					stairPath.Add(getStairFromFloorsAndStage(to, from, stage));	
				}
				stairTransitionPaths.Add(from+"-"+to, stairPath);
				//Debug.Log (from+"-"+to+" => "+stairPath.Count);
			}
			
			if(from < 4){
				//Going up
				int to = from +1;
				List<PathfindingBallStairs> stairPath = new List<PathfindingBallStairs>();
				for (int stage = 1; stage <= 4; stage++) {
					stairPath.Add(getStairFromFloorsAndStage(from, to, stage));	
				}
				stairTransitionPaths.Add(from+"-"+to, stairPath);
				//Debug.Log (from+"-"+to+" => "+stairPath.Count);
			}
		}
	}
	
	public static List<PathfindingBall> getPathfindingBallsForRoom(Room r){
		
		List<PathfindingBall> result = new List<PathfindingBall> ();
		
		foreach (PathfindingBall pb in GameController.PathfindingBalls){
			if (pb.RoomLeft == r.roomID){
				result.Add(pb);
			}else{
				if (pb.RoomRight == r.roomID){
					result.Add(pb);
				}
			}
		}
		
		return result;
	}
	
	public static Room getRoomFromID(string RoomID){
		foreach (Room r in GameController.Rooms) {
			if (r.roomID == RoomID) {
				return r;
			}
		}
		return null;
	}


}
