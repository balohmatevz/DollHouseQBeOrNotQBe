using UnityEngine;
using System.Collections;

public class MobEye : MonoBehaviour {
    Player player;

	// Use this for initialization
    void Start () {
        player = this.transform.parent.parent.parent.gameObject.GetComponent<Player>();
        //Debug.Log("player = "+player);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.statSleep < 5f)
        {
            this.renderer.material.color = new Color(216f / 255, 198f / 255, 140f / 255);
        } else
        {
            this.renderer.material.color = Color.black;
        }
	}
}
