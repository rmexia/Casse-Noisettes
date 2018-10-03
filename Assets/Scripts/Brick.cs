using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int healthPublic;
    static Color[] s_colors;
	// Use this for initialization
	void Start () {
        s_colors = new Color[4];
        s_colors[0] = new Color(0,0.5f,0);
        s_colors[1] = new Color(1, 1, 0);
        s_colors[2] = new Color(1, 0.5f, 0);
        s_colors[3] = new Color(0.5f, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (healthPublic == 0)
            Destroy(gameObject);
        else
        {
            GetComponent<Renderer>().material.SetColor("_Color",s_colors[healthPublic-1]);
         }
	}
}
