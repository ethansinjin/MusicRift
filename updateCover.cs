using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class updateCover : MonoBehaviour {
	public WWW w;
	public Texture2D tex;
	public string urlName = @"file:///Users/Jonah/Desktop/albums/art1.jpg";
	
	void Start()
	{
		w = new WWW (urlName);
		tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
		w.LoadImageIntoTexture (tex);
		renderer.material.mainTexture = tex;
	}
}

