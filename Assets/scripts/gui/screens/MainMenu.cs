﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture Logo;
	public GUISkin GuiSkin;

	public AudioClip SoundMouseOver;
	public AudioClip SoundMousePress;

	private Vector2 scrollPosition;
	private bool musicToggle = true;
	private bool soundToggle = true;
	private float musicVolume;
	private float musicVolumeMin = 0;
	private float musicVolumeMax = 1;
	private float soundVolume;
	private float soundVolumeMin = 0;
	private float soundVolumeMax = 1;
	private int screenMargin = 20;
	private int leftPanelWidth = 300;
	private int leftMargin = 0;

	private enum GUI_STATE {
		UI_STATE_DEFAULT = 0,
		UI_STATE_ONLINE = 1,
		UI_STATE_OFFLINE = 2,
		UI_STATE_OPTIONS = 3,
		UI_STATE_CREDITS = 4,
		UI_STATE_QUIT = 5
	};
	private GUI_STATE GuiState = 0;

	// Use this for initialization
	void Start () {
		leftMargin = leftPanelWidth + screenMargin * 2;

		if(musicToggle) {
			GetComponent<AudioSource>().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void DrawBaseGUI() {
		GUILayout.BeginArea(new Rect(screenMargin, screenMargin, leftPanelWidth, Screen.height - screenMargin));

		GUILayout.BeginVertical();
		GUILayout.Box(Logo, GUIStyle.none, GUILayout.Width(300), GUILayout.Height(300));

		if(GUILayout.Button(new GUIContent("Online", "b"))) {
			GuiState = GUI_STATE.UI_STATE_ONLINE;
			PlayMousePress();
		}

		if(GUILayout.Button(new GUIContent("Offline", "b"))) {
			PlayMousePress();
			//GuiState = GUI_STATE.UI_STATE_OFFLINE;
			Application.LoadLevel("level_testing");
		}

		if(GUILayout.Button(new GUIContent("Options", "b"))) {
			GuiState = GUI_STATE.UI_STATE_OPTIONS;
			PlayMousePress();
		}

		if(GUILayout.Button(new GUIContent("Credits", "b"))) {
			GuiState = GUI_STATE.UI_STATE_CREDITS;
			PlayMousePress();
		}

		if(GUILayout.Button(new GUIContent("Quit to desktop", "b"))) {
			GuiState = GUI_STATE.UI_STATE_QUIT;
			PlayMousePress();
		}

		GUILayout.EndVertical();

		GUILayout.EndArea();
	}

	private void DrawOnlineGUI() {

		GUILayout.BeginArea(new Rect(leftMargin, screenMargin, Screen.width - leftMargin - screenMargin, Screen.height - screenMargin));
		GUILayout.BeginHorizontal();
		if(GUILayout.Button(new GUIContent("Host Game", "b"))) {
			PlayMousePress();
		}
		if(GUILayout.Button(new GUIContent("Join Game", "b"))) {
			PlayMousePress();
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
	
	private void DrawOfflineGUI() {
		GUILayout.BeginArea(new Rect(leftMargin, screenMargin, Screen.width - leftMargin - screenMargin, Screen.height - screenMargin));
		GUILayout.BeginHorizontal();
		GUILayout.Label("Offline GUI");
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
	
	private void DrawOptionsGUI() {
		GUILayout.BeginArea(new Rect(leftMargin, screenMargin, Screen.width - leftMargin - screenMargin, Screen.height - screenMargin));

		GUILayout.BeginVertical();

		GUILayout.Label("Options GUI");

		GUILayout.BeginHorizontal("box");
		musicToggle = GUILayout.Toggle(musicToggle, "Music");
		musicVolume = GUILayout.HorizontalSlider(musicVolume, musicVolumeMin, musicVolumeMax);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal("box");
		soundToggle = GUILayout.Toggle(soundToggle, "Sound");
		soundVolume = GUILayout.HorizontalSlider(soundVolume, soundVolumeMin, soundVolumeMax);
		GUILayout.EndHorizontal();

		GUILayout.EndVertical();

		GUILayout.EndArea();

		CheckMusicSound();
	}

	private void DrawCreditsGUI() {
		GUILayout.BeginArea(new Rect(leftMargin, screenMargin, Screen.width - leftMargin - screenMargin, Screen.height - screenMargin * 2));
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, "box");
		GUILayout.Label("Lorem ipsum");
		GUILayout.TextArea("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tempus mauris et convallis hendrerit. Nam eget lacus non nibh lobortis vehicula et vel sem. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam tincidunt luctus neque ut blandit. Quisque ac ante at lorem pulvinar euismod. Quisque imperdiet sagittis massa. Ut vel est velit. In hac habitasse platea dictumst. Pellentesque sed mauris eu nibh mattis tincidunt. Maecenas eu dolor id erat gravida mollis. Proin est dui, eleifend cursus suscipit sit amet, tincidunt at massa. Phasellus purus purus, gravida ut fermentum nec, ornare in lacus. Mauris ac commodo neque. Aliquam at dignissim lacus. Donec vitae erat sed massa iaculis congue.");
		GUILayout.TextArea("Curabitur lorem mi, ullamcorper non felis at, suscipit sollicitudin est. Integer non lobortis justo, rutrum facilisis nibh. Proin feugiat in dui eu sollicitudin. Etiam tristique tempus luctus. Donec porta elementum aliquam. Sed consequat dolor mi, sit amet tincidunt tortor pellentesque sit amet. Nam purus metus, lobortis sed lacinia vel, vestibulum ut mi. Fusce hendrerit et quam quis lobortis. Nullam vitae feugiat ligula, vel pellentesque augue. Curabitur quis mattis leo. Quisque pharetra nibh et dui feugiat adipiscing id et mauris. Sed suscipit magna quis nibh lacinia fringilla. Vestibulum porttitor, nunc quis congue hendrerit, est purus condimentum purus, vel venenatis sapien sapien quis sapien. Ut ante ipsum, vehicula eget varius nec, lobortis sed ligula. Suspendisse placerat, ante a tincidunt dapibus, ligula nulla bibendum lacus, eu dignissim elit massa non mauris.");
		GUILayout.TextArea("Aenean varius mauris dui, non congue tortor ultricies id. Nullam ut orci diam. Praesent ultrices fringilla purus, non congue erat venenatis vel. Suspendisse at dapibus arcu. Vestibulum facilisis erat magna, sit amet dignissim sapien ullamcorper nec. Suspendisse eros nibh, convallis vulputate massa ut, dignissim scelerisque augue. Nullam pharetra et elit et viverra. Proin ac magna nec turpis fringilla laoreet sit amet eget est.");
		GUILayout.TextArea("Donec enim nisi, posuere in diam et, interdum pellentesque turpis. Integer ac malesuada turpis. Donec augue nisi, gravida sit amet turpis vitae, hendrerit rutrum velit. Nullam ac ipsum sem. Morbi eros enim, rutrum vel mi venenatis, congue elementum sem. Integer mattis semper accumsan. Etiam eleifend iaculis lectus, eu porttitor mauris interdum quis. Suspendisse blandit purus non orci vestibulum laoreet. Nullam vel lectus vitae libero tempus porttitor sit amet quis tellus. Sed sed placerat nibh. Ut rhoncus non odio quis ullamcorper. Vivamus sit amet massa ut mauris laoreet dignissim id a purus. Duis eu interdum nulla. Phasellus iaculis mattis felis, at accumsan est tristique at. Morbi tincidunt tortor sed aliquet egestas.");
		GUILayout.TextArea("Quisque est purus, euismod vitae turpis in, placerat feugiat mi. Proin scelerisque at tellus nec adipiscing. Sed neque justo, hendrerit eget feugiat quis, ornare non purus. Integer egestas suscipit luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In nisi nulla, lobortis ac tempor at, consectetur nec ligula. Donec est massa, dapibus quis massa vel, lobortis hendrerit velit. Praesent mollis lectus at magna pretium tincidunt. Nunc ac nunc sit amet nulla bibendum varius vel ut turpis. Praesent auctor malesuada orci, in semper nunc volutpat");
		GUILayout.EndScrollView();
		GUILayout.EndArea();
	}

	private void DrawQuitGameConfirationGUI() {
		int boxWidth = 400;
		int boxHeight = 200;
		GUILayout.BeginArea(new Rect(Screen.width / 2 - boxWidth / 2, Screen.height / 2 - boxHeight / 2, boxWidth, boxHeight));

		GUILayout.Label("Really quit?");

		GUILayout.BeginHorizontal();

		if(GUILayout.Button("Yes")) {
			Application.Quit();
		}

		if(GUILayout.Button("No")) {
			GuiState = GUI_STATE.UI_STATE_DEFAULT;
		}

		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

	void OnMouseOver() {
		if(soundToggle) {
			GetComponent<AudioSource>().PlayOneShot(SoundMouseOver);
		}
	}
	
	void OnMouseOut() {
	}

	private void PlayMousePress() {
		if(soundToggle) {
			GetComponent<AudioSource>().PlayOneShot(SoundMousePress);
		}
	}

	private void CheckMusicSound() {
		if(musicToggle==false) {
			GetComponent<AudioSource>().Stop();
		} else {
			GetComponent<AudioSource>().volume = musicVolume;
			if(!GetComponent<AudioSource>().isPlaying) {
				GetComponent<AudioSource>().Play();
			}
		}

		if (soundToggle == false) {
			AudioListener.volume = 0;	
		} else {
			AudioListener.volume = soundVolume;
		}
	}

	string lastTooltip = " ";
	void OnGUI () {
		GUI.skin = GuiSkin;

		switch(GuiState) {
		case GUI_STATE.UI_STATE_DEFAULT:
			DrawBaseGUI();
			break;
		case GUI_STATE.UI_STATE_ONLINE:
			DrawBaseGUI();
			DrawOnlineGUI();
			break;
		case GUI_STATE.UI_STATE_OFFLINE:
			DrawBaseGUI();
			DrawOfflineGUI();
			break;
		case GUI_STATE.UI_STATE_OPTIONS:
			DrawBaseGUI();
			DrawOptionsGUI();
			break;
		case GUI_STATE.UI_STATE_CREDITS:
			DrawBaseGUI();
			DrawCreditsGUI();
			break;
		case GUI_STATE.UI_STATE_QUIT:
			DrawQuitGameConfirationGUI();
			break;
		default:
			break;
		}

		if (Event.current.type == EventType.Repaint && GUI.tooltip != lastTooltip) {        
			if (lastTooltip != "") {
				SendMessage ("OnMouseOut", SendMessageOptions.DontRequireReceiver);      
			} 
			
			if (GUI.tooltip != "") {
				SendMessage ("OnMouseOver", SendMessageOptions.DontRequireReceiver);
			}
			
			lastTooltip = GUI.tooltip; 
		}
	}
}
