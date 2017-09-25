using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Texture2D crosshairImage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
	}

    void OnGUI()
    {
        float imageScale = 5;

        float xMin = (Screen.width / 2) - (crosshairImage.width / 6);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 6);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width / imageScale, crosshairImage.height / imageScale), crosshairImage);
    }
}
