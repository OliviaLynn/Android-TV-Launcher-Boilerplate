# Android TV Launcher
<img src="https://img.shields.io/badge/Android-9 (Pie)-blue"> <img src="https://img.shields.io/badge/Unity-2017.4.34f1-blue"> <img src="https://img.shields.io/badge/maintained%3F-yes-green" /> <img src="https://img.shields.io/github/issues/OliviaLynn/Android-TV-Launcher" /> 

A boilerplate for making your own Android TV launcher in Unity, and a tutorial for setting the app you create as your default Android TV launcher via adb commands.

This launcher is minimal, and allows you to expose a selected set of apps to the user (our use case involves giving our Airbnb guests access to Chrome, as well as TV apps like Netflix and Hulu). If you'd rather take a more traditional approach and list all available apps, you will want to extend the code.

## Getting Started

### Prerequisites

- This was built in **Unity 2017.4.34f** (but I don't expect it to make much of a difference).
- This was built for a **Greatlizard Android TV**, while following instructions written for Shield TV (I also don't expect this to make much of a difference).
- Our Android TVs are running **Android 9 (Pie)**, so the following adb commands are for this version.

### Setup

## The Code
Just plop `AppLauncher.cs` into an empty GameObject in your scene. This will give you the ability to hit hotkeys to launch apps; of course, you can make changes to which apps you'd like to be able to launch. If you want to see a little menu of hotkey/app pairs, drag a text box in your scene into the AppLauncher's Text Box public variable.
 
## The Manifest
Create directories in your `Assets` folder such that you can place the included manifest so its path is `Assets/Plugins/Android/AndroidManifest.xml`. (The part of the manifest that makes this a launcher is the line with `android.intent.category.HOME`).

## Android TV
Developer Mode: On your Android TV, go to `Settings` > `About`, then click `Build` seven times. You should see a little popup telling you you're now in Developer Mode.

IP Address: Go to `About` > `Status` to find your Android TV's IP address, and write this down somewhere.

## ADB Connection
Make sure you have adb set up on your computer.

In your shell, type `adb connect <your Android TV's IP address>`. This will let you push the app directly from your computer to your Android TV without having to fumble around with a USB drive (and also let you look at console logs that the Android app outputs). 

Go ahead and get your app onto your Android TV (in Unity, `Ctrl` + `Shift` + `B` to open Build Settings, then click `Build and Run`. If your adb is connected properly, your app will start running on your TV).

## Disable Default Launcher
First of all (and this is very important!), **you should install a functional launcher** from the Play store as a backup. We're going to disable the built-in launcher, and the launcher we're replacing it with does not come with all the functionality of a standard launcher. Even if you do build it in, it's nice to have a backup, just in case.

Then, identify the package name of your default launcher. Mine was called `com.oranth.tvlauncher`. You can run `adb shell pm list packages` in your shell to see a list of all of the packages on your Android TV and to find your own.

For Android 9, you'll want to run `adb shell pm uninstall -k --uesr 0 <name of your default launcher>` in your shell. For Android versions 6-8, you can find the alternative commands in [this post](https://forum.xda-developers.com/shield-tv/themes-apps/alternate-launcher-root-marshmallow-t3359076).

Now, when you hit your Home button, you'll get to choose either the launcher you downloaded or the launcher you built as your new default launcher.
