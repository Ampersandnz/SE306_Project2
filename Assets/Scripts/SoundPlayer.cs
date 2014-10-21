using UnityEngine;
using System.Collections;

// Class to load and play sound. NEVER destroy this across scenes!
public class SoundPlayer : MonoBehaviour {
	// Booleans to toggle music and sound.
	public bool music;
	public bool sound;

	// Audio sources for music.
	GameObject menuMusic;
	AudioSource menuMusicSound;

	GameObject storyMusic;
	AudioSource storyMusicSound;

	// Audio sources for sound effects.
	GameObject applause;
	AudioSource applauseSound;
	
	GameObject bounce;
	AudioSource bounceSound;
	
	GameObject cashRegister;
	AudioSource cashRegisterSound;

	GameObject crunch;
	AudioSource crunchSound;
	
	GameObject health;
	AudioSource healthSound;

	GameObject hit;
	AudioSource hitSound;
	
	GameObject menuSelect;
	AudioSource menuSelectSound;
	
	GameObject ohMan;
	AudioSource ohManSound;

	// Loading everything.
	void Awake () {


		music = true;
		sound = true;

		LoadMusic ();
		LoadSoundEffects ();

		//Check if the music was toggled off last time the game was played
		if (PlayerPrefs.HasKey ("SwiperMusic")) {
			if(PlayerPrefs.GetInt("SwiperMusic")==0){
				ToggleMusic("menu");
			}
		}
		if (PlayerPrefs.HasKey ("SwiperSound")) {
			if(PlayerPrefs.GetInt("SwiperSound")==0){
				ToggleSound();
			}
		}

	}


	// Function to toggle music. INPUTS:
	// 	- sceneType: string. Represents the type of scene the player is currently in. Values include "menu" or "story".
	public void ToggleMusic (string sceneType){
		if (music == true) {
			music = false;
			storyMusicSound.Stop ();
			menuMusicSound.Stop ();
			PlayerPrefs.SetInt("SwiperMusic",0);
		} else {
			music = true;
			PlayerPrefs.SetInt("SwiperMusic",1);
			if(sceneType=="menu"){
				PlayMenuMusic ();
			}else if(sceneType=="story"){
				PlayStoryMusic ();
			}
		}
	}

	// Function to toggle the sound effects on or off.
	public void ToggleSound (){
		if (sound == true) {
			sound = false;
			PlayerPrefs.SetInt("SwiperSound",0);
		} else {
			sound = true;
			PlayerPrefs.SetInt("SwiperSound",1);
		}
	}

	// Load the files for the  music.
	public void LoadMusic(){
		menuMusic = GameObject.Find ("Menu music");
		menuMusicSound = menuMusic.GetComponent<AudioSource> ();
		menuMusicSound.loop = true;
		DontDestroyOnLoad (menuMusic);

		storyMusic = GameObject.Find ("Story music");
		storyMusicSound = storyMusic.GetComponent<AudioSource> ();
		storyMusicSound.loop = true;
		DontDestroyOnLoad (storyMusic);
	}

	// Load files for the sound effects.
	public void LoadSoundEffects (){
		applause = GameObject.Find ("Applause sound");
		applauseSound = applause.GetComponent<AudioSource> ();
		DontDestroyOnLoad (applause);

		bounce = GameObject.Find ("Bounce sound");
		bounceSound = bounce.GetComponent<AudioSource> ();
		DontDestroyOnLoad (bounce);

		cashRegister = GameObject.Find ("Cash register sound");
		cashRegisterSound = cashRegister.GetComponent<AudioSource> ();
		DontDestroyOnLoad (cashRegister);
		
		crunch = GameObject.Find ("Crunch sound");
		crunchSound = crunch.GetComponent<AudioSource> ();
		DontDestroyOnLoad (crunch);

		health = GameObject.Find ("Health sound");
		healthSound = health.GetComponent<AudioSource> ();
		DontDestroyOnLoad (health);
		
		hit = GameObject.Find ("Hit sound");
		hitSound = hit.GetComponent<AudioSource> ();
		DontDestroyOnLoad (hit);

		menuSelect = GameObject.Find ("Menu selection sound");
		menuSelectSound = menuSelect.GetComponent<AudioSource> ();
		DontDestroyOnLoad (menuSelect);
		
		ohMan = GameObject.Find ("Oh man sound");
		ohManSound = ohMan.GetComponent<AudioSource> ();
		DontDestroyOnLoad (ohMan);
	}


	// Play the menu music if music is enabled.
	public void PlayMenuMusic(){
		if (music == true) {
			storyMusicSound.Stop ();
			menuMusicSound.Play ();
		}
	}

	// Play the story music if music is enabled.
	public void PlayStoryMusic(){
		if (music == true) {
			menuMusicSound.Stop ();
			storyMusicSound.Play ();
		}
	}

	// Play a sound effect if sound is enabled. INPUTS:
	//	- sound_clip: string. The sound to play. Can choose from:
	//		"applause"
	//		"bounce"
	//		"cash register"
	//		"crunch"
	//		"health"
	//		"hit"
	//		"menu"
	//		"oh man"
	//		"wasted"
	public void PlaySoundEffect(string sound_clip){
		if (sound == true) {
			if (sound_clip == "applause") {
				applauseSound.Play ();
			}else if(sound_clip == "bounce"){
				bounceSound.Play ();
			}else if(sound_clip=="cash register"){
				cashRegisterSound.Play ();
			}else if(sound_clip=="crunch"){
				crunchSound.Play ();
			}else if(sound_clip=="health"){
				healthSound.Play ();
			}else if(sound_clip=="hit"){
				hitSound.Play ();
			}else if(sound_clip=="menu"){
				menuSelectSound.Play ();
			}else if (sound_clip=="oh man"){
				ohManSound.Play ();
			}
		}
	}

	// Sounds to play when Swiper dies.
	public void Death(){
		storyMusicSound.Stop ();
		PlaySoundEffect ("oh man");
	}
}
