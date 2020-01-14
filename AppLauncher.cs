using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLauncher : MonoBehaviour {

    [Tooltip("Will write out a menu of hotkeys/app pairs.")]
    public UnityEngine.UI.Text textBox;

	void Start () {


        if (textBox)
        {
            string[] messages =
            {
                "Hello, Olivia!",
                "Press 's' to go to Android TV Settings",
                "Press 'c' to launch Chrome",
                "Press 'y' to launch Youtube",
                "Press 'a' to launch ATV Launcher",
                "Press 'n' to launch Netflix",
                "Press 'h' to launch Hulu"
            };
            textBox.text = string.Join("\n", messages);
        }
    }
	
	void Update ()
    {
        if (Input.GetKeyDown("s"))
        {
            LaunchApp("com.android.tv.settings");
        }
        if (Input.GetKeyDown("c"))
        {
            LaunchApp("com.android.chrome");
        }
        if (Input.GetKeyDown("y"))
        {
            LaunchApp("com.google.android.youtube.tv");
        }
        if (Input.GetKeyDown("a"))
        {
            LaunchApp("ca.dstudio.atvlauncher.free");
        }
        if (Input.GetKeyDown("n"))
        {
            LaunchApp("com.netflix.mediaclient");
        }
        if (Input.GetKeyDown("h"))
        {
            LaunchApp("com.hulu.plus");
        }
    }

    void LaunchApp(string bundleId) {

            bool fail = false;

            //string bundleId = "com.android.chrome"; // your target bundle id

            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

            AndroidJavaObject launchIntent = null;
            try
            {
                launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleId);
            }
            catch (System.Exception e)
            {
                fail = true;
            }

            if (fail)
            { //open app in store
                Application.OpenURL("https://google.com");
            }
            else //open the app
                ca.Call("startActivity", launchIntent);

            up.Dispose();
            ca.Dispose();
            packageManager.Dispose();
            launchIntent.Dispose();
        }
}
