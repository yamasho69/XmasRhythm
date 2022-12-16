using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour {

	// メンバ変数
	[NonSerialized]public int highscore = 0;			// 現在のスコア
	public bool isClear;
	public AudioClip bgm;
    //private AudioSource audioSource;// オーディオソース

    [NonSerialized] public int score;

	[SerializeField] Text countDownText = default;
	[SerializeField] GameObject resultPanel = default;
	[SerializeField] Text scoreText = default;


	//タイムライン再生
	[SerializeField] PlayableDirector playableDirector;

	SoundManager soundManager;

	// Use this for initialization
	void Start () {
		// オーディオソース取得
		//GameObject gameObject = GameObject.FindGameObjectWithTag("SoundManager");
		//soundManager = gameObject.GetComponent<SoundManager> ();
		//soundManager.PlayBgm(bgm);

		highscore = ES3.Load<int>("HIGHSCORE", defaultValue: 0);
		isClear = ES3.Load<bool>("CLEAR", defaultValue:false);

		StartCoroutine(GameMain());
	}

	IEnumerator GameMain() {
        countDownText.text = "3";
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        yield return new WaitForSeconds(1);
        countDownText.text = "GO!";
        yield return new WaitForSeconds(0.3f);
        countDownText.text = "";
        playableDirector.Play();
    }

	[Button]public void AddScore(int point) {
		score += point;
		scoreText.text = score.ToString();
	}


	// ゲームデータをセーブ
	void SaveGameData () {
		ES3.Save<int>("HIGHSCORE", highscore);
		ES3.Save<bool>("CLEAR", isClear);
	}

	public void OnEndEvent() {
		resultPanel.SetActive(true);
		Debug.Log("終わった");
	}

	public void OnRetry() {
        // 現在のSceneを取得
        Scene loadScene = SceneManager.GetActiveScene();
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(loadScene.name);
    }
}
