using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    int scrollingEdge = 20;
    float scrollSpeed = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (transform.position.z < -3){
                transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * 4);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (transform.position.z > -14){
                transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * 4);
            }
        }



        if (Input.mousePosition.x < scrollingEdge || Input.GetKey(KeyCode.A))
        {
            if(transform.position.x > -10){
                //left
                transform.Translate(Vector3.right * -scrollSpeed);
            }
        }
        if (Input.mousePosition.x > Screen.width - scrollingEdge || Input.GetKey(KeyCode.D))
        {
            if(transform.position.x < 10){
                //right
                transform.Translate(Vector3.right * scrollSpeed);
            }
        }

        if (Input.mousePosition.y < scrollingEdge || Input.GetKey(KeyCode.S))
        {
            if(transform.position.y > 1){
                //down
                transform.Translate(Vector3.up * -scrollSpeed);
            }
        }
        if (Input.mousePosition.y > Screen.height - scrollingEdge || Input.GetKey(KeyCode.W))
        {
            if(transform.position.y < 9){
                //up
                transform.Translate(Vector3.up * scrollSpeed);
            }
        }
	}
}
