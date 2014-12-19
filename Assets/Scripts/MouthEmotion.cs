using UnityEngine;
using System.Collections;

public class MouthEmotion : MonoBehaviour {

    Player player;

	// Use this for initialization
	void Start () {
        player = this.transform.parent.parent.parent.parent.gameObject.GetComponent<Player>();
        //Debug.Log("player = "+player);
	}
	
	// Update is called once per frame
	void Update () {
        float y = (-1f + (player.statFun / 100f));
        Vector3 v = this.transform.localPosition;
        v.y = y;
        this.transform.localPosition = v;
	}
}
