using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

    void OnMouseDown(){
        Debug.Log("ABC");
        Application.Quit();
    }
}
