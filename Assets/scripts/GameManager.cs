using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public delegate void GameDelegate();
	public static event GameDelegate OnGameStarted;
	public static event GameDelegate OnGameOverConfirmed;

	public static GameManager Instance;

	public GameObject gameOverPage;
	public GameObject countdownPage;
	public Text scoreText;

	enum PageState {
		None,
		Countdown,
		GameOver
	}

	int score = 0;
	bool gameOver = true;

	public bool GameOver { get { return gameOver; } }

	void Awake() {
		if (Instance != null) {
			Destroy(gameObject);
		}
		else {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void OnEnable() {
		TapController.OnPlayerDied += OnPlayerDied;
		TapController.OnPlayerScored += OnPlayerScored;
		CountdownText.OnCountdownFinished += OnCountdownFinished;
	}

	void OnDisable() {
		TapController.OnPlayerDied -= OnPlayerDied;
		TapController.OnPlayerScored -= OnPlayerScored;
		CountdownText.OnCountdownFinished -= OnCountdownFinished;
	}

	void OnCountdownFinished() {
		SetPageState(PageState.None);
		OnGameStarted();
		score = 0;
		gameOver = false;
	}

	void OnPlayerScored() {
		score++;
		scoreText.text = score.ToString();
		if (score == 10) {
			SceneManager.LoadScene("3");
		}
	}

	void OnPlayerDied() {
		gameOver = true;
		int savedScore = PlayerPrefs.GetInt("HighScore");
		if (score > savedScore) {
			PlayerPrefs.SetInt("HighScore", score);
		}
		SetPageState(PageState.GameOver);
	}

	void SetPageState(PageState state) {
		switch (state) {
			case PageState.None:
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				break;
			case PageState.Countdown:
				gameOverPage.SetActive(false);
				countdownPage.SetActive(true);
				break;
			case PageState.GameOver:
				gameOverPage.SetActive(true);
				countdownPage.SetActive(false);
				break;
		}
	}
	
	public void ConfirmGameOver() {
		SetPageState(PageState.Countdown);
		scoreText.text = "0";
		OnGameOverConfirmed();
	}

	public void StartGame() {
		SetPageState(PageState.Countdown);
	}

}
