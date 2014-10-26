using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;


public class updateCover : MonoBehaviour {
	public WWW w;
	public Texture2D tex;
	public string urlPath = @"file:///Users/ethangill/Desktop/albums/";
	public bool updateAlbumArt = false;

	IEnumerator Start(){
//		ProcessStartInfo proc = new ProcessStartInfo("osascript", "~/Documents/getArt.scpt");
//		proc.UseShellExecute = true;
//		Process.Start(proc);
		GameObject[] cubes = new GameObject [9];
		cubes[0] = GameObject.Find("Cube1");
		cubes[1] = GameObject.Find("Cube2");
		cubes[2] = GameObject.Find("Cube3");
		cubes[3] = GameObject.Find("Cube4");
		cubes[4] = GameObject.Find("Cube5");
		cubes[5] = GameObject.Find("Cube6");
		cubes[6] = GameObject.Find("Cube7");
		cubes[7] = GameObject.Find("Cube8");
		cubes[8] = GameObject.Find("Cube9");
		
		for (int i=0; i<9; i++) {
			
			tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
			WWW www = new WWW(urlPath+"art"+(i+1)+".jpg");
			yield return www;
			if (!System.String.IsNullOrEmpty(www.error)) {
				UnityEngine.Debug.Log(www.error);
				//jpg doesn't exist, try png
				WWW ww2 = new WWW(urlPath+"art"+(i+1)+".png");
				yield return ww2;
				if (System.String.IsNullOrEmpty(ww2.error)) {
					ww2.LoadImageIntoTexture(tex);
				}else{
					//neither png nor jpg
					//something's fucky
					UnityEngine.Debug.Log(ww2.error);
				}
			}else{
				//it was jpg
				www.LoadImageIntoTexture (tex);
			}
			cubes[i].renderer.material.mainTexture = tex;
			
		}
		//IEnumerator num = loadAlbumArt();


	}

	void Update(){
//		if (Input.GetKeyDown ("i")) {
//			updateAlbumArt = true;
//		}
//
//		if (updateAlbumArt) {
//			updateAlbumArt = false;
//			Debug.Log ("Reloading Album Art");
//			loadAlbumArt();
//		}
	}

	
//	IEnumerator loadAlbumArt(){
//			GameObject[] cubes = new GameObject [9];
//			cubes[0] = GameObject.Find("Cube1");
//			cubes[1] = GameObject.Find("Cube2");
//			cubes[2] = GameObject.Find("Cube3");
//			cubes[3] = GameObject.Find("Cube4");
//			cubes[4] = GameObject.Find("Cube5");
//			cubes[5] = GameObject.Find("Cube6");
//			cubes[6] = GameObject.Find("Cube7");
//			cubes[7] = GameObject.Find("Cube8");
//			cubes[8] = GameObject.Find("Cube9");
//			
//			for (int i=0; i<9; i++) {
//				
//				tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
//				WWW www = new WWW(urlPath+"art"+(i+1)+".jpg");
//				yield return www;
//				if (!System.String.IsNullOrEmpty(www.error)) {
//					Debug.Log(www.error);
//					//jpg doesn't exist, try png
//					WWW ww2 = new WWW(urlPath+"art"+(i+1)+".png");
//					yield return ww2;
//					if (System.String.IsNullOrEmpty(ww2.error)) {
//						ww2.LoadImageIntoTexture(tex);
//					}else{
//						//neither png nor jpg
//						//something's fucky
//						Debug.Log(ww2.error);
//					}
//				}else{
//					//it was jpg
//					www.LoadImageIntoTexture (tex);
//				}
//				cubes[i].renderer.material.mainTexture = tex;
//				
//			}
//	}
}

