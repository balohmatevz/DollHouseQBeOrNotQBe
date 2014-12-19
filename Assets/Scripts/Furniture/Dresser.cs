using UnityEngine;
using System.Collections;

public class Dresser : Furniture {
    public override void OnInteract(){
        foreach (Transform t in playerUsingThis.gameObject.transform)
        {
            foreach (Transform t2 in t)
            {
                foreach (Transform t3 in t2)
                {
                    if(t3.name == "Clothing"){
                        switch(t3.gameObject.renderer.material.color.ToString()){
                            case "RGBA(1.000, 1.000, 1.000, 1.000)":
                                t3.gameObject.renderer.material.color = new Color(1.000f, 0.000f, 0.000f);
                                break;
                            case "RGBA(1.000, 0.000, 0.000, 1.000)":
                                t3.gameObject.renderer.material.color = new Color(1.000f, 1.000f, 0.000f);
                                break;
                            case "RGBA(1.000, 1.000, 0.000, 1.000)":
                                t3.gameObject.renderer.material.color = new Color(0.000f, 1.000f, 0.000f);
                                break;
                            case "RGBA(0.000, 1.000, 0.000, 1.000)":
                                t3.gameObject.renderer.material.color = new Color(0.000f, 1.000f, 1.000f);
                                break;
                            case "RGBA(0.000, 1.000, 1.000, 1.000)":
                                t3.gameObject.renderer.material.color = new Color(0.000f, 0.000f, 1.000f);
                                break;
                            case "RGBA(0.000, 0.000, 1.000, 1.000)":
                                t3.gameObject.renderer.material.color = new Color(1.000f, 0.000f, 1.000f);
                                break;
                            case "RGBA(1.000, 0.000, 1.000, 1.000)":
                                t3.gameObject.renderer.material.color = new Color(0.000f, 0.000f, 0.000f);
                                break;
                            case "RGBA(0.000, 0.000, 0.000, 1.000)":
                                t3.gameObject.renderer.material.color = new Color(1.000f, 1.000f, 1.000f);
                                break;
                            default:
                                t3.gameObject.renderer.material.color = new Color(1.000f, 1.000f, 1.000f);
                                break;
                        }
                    }
                }
            }
        }

    }
}
