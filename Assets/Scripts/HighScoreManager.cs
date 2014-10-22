using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Adapted from http://answers.unity3d.com/questions/20773/how-do-i-make-a-highscores-board.html

/// <summary>
/// High score manager.
/// Local highScore manager for LeaderboardLength number of entries
/// 
/// this is a singleton class.  to access these functions, use HighScoreManager._instance object.
/// eg: HighScoreManager._instance.SaveHighScore("meh",1232);
/// No need to attach this to any game object, thought it would create errors attaching.
/// </summary>

public class HighScoreManager : MonoBehaviour{

	private static HighScoreManager m_instance;
	private const int LeaderboardLength = 5;
	
	public static HighScoreManager _instance {
		get {
			if (m_instance == null) {
				m_instance = new GameObject ("HighScoreManager").AddComponent<HighScoreManager> ();                
			}
			return m_instance;
		}
	}
	
	void Awake (){
		if (m_instance == null) {
			m_instance = this;          
		} else if (m_instance != this)      
			Destroy (gameObject);   
		
		DontDestroyOnLoad (gameObject);
	}
	
	public void SaveHighScore (string name, int score){
		List<Scores> HighScores = new List<Scores> ();
		
		int i = 1;
		while (i<=LeaderboardLength && PlayerPrefs.HasKey("SwiperHighscore"+i+"score")) {
			Scores temp = new Scores ();
			temp.score = PlayerPrefs.GetInt ("SwiperHighscore" + i + "score");
			temp.name = PlayerPrefs.GetString ("SwiperHighscore" + i + "name");
			HighScores.Add (temp);
			i++;
		}
		if (HighScores.Count == 0) {            
			Scores _temp = new Scores ();
			_temp.name = name;
			_temp.score = score;
			HighScores.Add (_temp);
		} else {
			for (i=1; i<=HighScores.Count && i<=LeaderboardLength; i++) {
				if (score > HighScores [i - 1].score) {
					Scores _temp = new Scores ();
					_temp.name = name;
					_temp.score = score;
					HighScores.Insert (i - 1, _temp);
					break;
				}           
				if (i == HighScores.Count && i < LeaderboardLength) {
					Scores _temp = new Scores ();
					_temp.name = name;
					_temp.score = score;
					HighScores.Add (_temp);
					break;
				}
			}
		}
		
		i = 1;
		while (i<=LeaderboardLength && i<=HighScores.Count) {
			PlayerPrefs.SetString ("SwiperHighscore" + i + "name", HighScores [i - 1].name);
			PlayerPrefs.SetInt ("SwiperHighscore" + i + "score", HighScores [i - 1].score);
			i++;
		}
		
	}

	//Check if a given score would be a highscore
	public bool isHighScore(int score){
		List<Scores> HighScores = new List<Scores> ();

		//Load playerprefs
		int i = 1;
		while (i<=LeaderboardLength && PlayerPrefs.HasKey("SwiperHighscore"+i+"score")) {
			Scores temp = new Scores ();
			temp.score = PlayerPrefs.GetInt ("SwiperHighscore" + i + "score");
			temp.name = PlayerPrefs.GetString ("SwiperHighscore" + i + "name");
			HighScores.Add (temp);
			i++;
		}
		//Test if it is a high score
		if (HighScores.Count == 0) {            
			return true;
		} else {
			for (i=1; i<=HighScores.Count && i<=LeaderboardLength; i++) {
				if (score > HighScores [i - 1].score) {
					return true;
				}           
				if (i == HighScores.Count && i < LeaderboardLength) {
					return true;
				}
			}
		}
		//Return false if it is not a highscore
		return false;
	}
	
	public List<Scores>  GetHighScore (){
		List<Scores> HighScores = new List<Scores> ();
		
		int i = 1;
		while (i<=LeaderboardLength && PlayerPrefs.HasKey("SwiperHighscore"+i+"score")) {
			Scores temp = new Scores ();
			temp.score = PlayerPrefs.GetInt ("SwiperHighscore" + i + "score");
			temp.name = PlayerPrefs.GetString ("SwiperHighscore" + i + "name");
			HighScores.Add (temp);
			i++;
		}
		
		return HighScores;
	}

	//Delete the high scores
	public void ClearLeaderBoard ()
	{
		List<Scores> HighScores = GetHighScore();
		
		for(int i=1;i<=HighScores.Count;i++)
		{
			PlayerPrefs.DeleteKey("SwiperHighscore" + i + "name");
			PlayerPrefs.DeleteKey("SwiperHighscore" + i + "score");
		}
	}
	
	void OnApplicationQuit(){
		PlayerPrefs.Save();
	}
}

public class Scores
{
	public int score;
	
	public string name;
	
}