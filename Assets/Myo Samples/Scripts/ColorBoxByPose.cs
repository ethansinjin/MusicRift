using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
public class ColorBoxByPose : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;

    // Materials to change to when poses are made.
    public Material waveInMaterial;
    public Material waveOutMaterial;
    public Material thumbToPinkyMaterial;

    // The pose from the last update. This is used to determine if the pose has changed
    // so that actions are only performed upon making them rather than every frame during
    // which they are active.
    private Pose _lastPose = Pose.Unknown;

    // Update is called once per frame.
    void Update ()
    {
        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

        // Check if the pose has changed since last update.
        // The ThalmicMyo component of a Myo game object has a pose property that is set to the
        // currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
        // detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
        // is not on a user's arm, pose will be set to Pose.Unknown.
        if (thalmicMyo.pose != _lastPose) {
            _lastPose = thalmicMyo.pose;

            // Vibrate the Myo armband when a fist is made.
            if (thalmicMyo.pose == Pose.Fist) {
                thalmicMyo.Vibrate (VibrationType.Medium);
				int numberOfSelection = 5;
				//string command = "osascript /Users/ethangill/Documents/playSong.scpt " + numberOfSelection;
				//UnityEngine.Debug.Log (command);
				//System.Diagnostics.Process.Start("/Users/ethangill/Documents/playsong.app/Contents/MacOS/applet --args " + numberOfSelection);
				//System.Diagnostics.Process.Start(command);
				System.Diagnostics.Process.Start("open", "-a playsong"+numberOfSelection);
				//System.Diagnostics.Process.Start("open", "-a Terminal --args osascript /Users/ethangill/Documents/playsong.scpt 5");

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

					GameObject myoo = GameObject.Find("Stick");
					GameObject closest = GameObject.Find ("Cube1");
					double distance = 9999.00;

//				Vector3 fwd = myoo.transform.TransformDirection(Vector3.forward);
//				RaycastHit hit;
//				Physics.Raycast(myoo.transform.position, fwd, out hit);
//					UnityEngine.Debug.DrawLine(myoo.transform.position, hit.point);
					for(int i = 0;i<9;i++){
					float temp = new Vector3(myoo.transform.position.x-cubes[i].transform.position.x, myoo.transform.position.y-cubes[i].transform.position.y, myoo.transform.position.z-cubes[i].transform.position.z).magnitude;
						if(temp < distance) {
							distance = temp;
							closest = cubes[i];
						}
					}


				if(closest == cubes[0]){
					System.Diagnostics.Process.Start("open", "-a playsong1");
			}else if(closest == cubes[1]){
					System.Diagnostics.Process.Start("open", "-a playsong2");
				}else if(closest == cubes[2]){
					System.Diagnostics.Process.Start("open", "-a playsong3");
				}else if(closest == cubes[3]){
					System.Diagnostics.Process.Start("open", "-a playsong4");
				}else if(closest == cubes[4]){
					System.Diagnostics.Process.Start("open", "-a playsong5");
				}else if(closest == cubes[5]){
					System.Diagnostics.Process.Start("open", "-a playsong6");
				}else if(closest == cubes[6]){
					System.Diagnostics.Process.Start("open", "-a playsong7");
				}else if(closest == cubes[7]){
					System.Diagnostics.Process.Start("open", "-a playsong8");
				}else if(closest == cubes[8]){
					System.Diagnostics.Process.Start("open", "-a playsong9");
				}
					
					

            // Change material when wave in, wave out or thumb to pinky poses are made.
            } else if (thalmicMyo.pose == Pose.WaveIn) {
                renderer.material = waveInMaterial;
            } else if (thalmicMyo.pose == Pose.WaveOut) {
                renderer.material = waveOutMaterial;
            } else if (thalmicMyo.pose == Pose.ThumbToPinky) {
                renderer.material = thumbToPinkyMaterial;
            }
        }
    }
}
