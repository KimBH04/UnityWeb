using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public GameObject resultPanel;
    public TMP_Text scoreText;
    public TMP_Text bestText;

    public TMP_Text hudText;
    public GameObject newBestText;

    public GameObject startPanel;

    private void Start()
    {
        Time.timeScale = 0f;
        startPanel.SetActive(true);
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        score = Mathf.Max(0, score + amount);
        hudText.text = score.ToString();
    }

    public void GameOver()
    {   
        string key = "Best_" + SceneManager.GetActiveScene().name;
        int best = PlayerPrefs.GetInt(key, 0);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt(key, best);
            PlayerPrefs.Save();
            newBestText.SetActive(true);
            ScoreSaver.Instance.Save(best);
        }

        scoreText.text = "SCORE: " + score;
        bestText.text = "BEST: " + best;
        resultPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    static int playCount;
    static float lastAdTime = -999f;                     // 마지막 전면 광고를 띄운 시각
    public float adCooldown = 30f;                       // 전면 광고 사이의 최소 간격 (초)

    public void Restart()                                // 실습 2 의 Restart 를 이렇게 교체
    {
        playCount++;
        bool enoughPlays = playCount >= 2;                                       // 첫 판 뒤에는 띄우지 않음
        bool enoughTime = Time.realtimeSinceStartup - lastAdTime > adCooldown;   // 마지막 광고 뒤 일정 시간
        if (enoughPlays && enoughTime && DummyAds.Instance.IsInterstitialReady())
        {
            lastAdTime = Time.realtimeSinceStartup;
            DummyAds.Instance.ShowInterstitial(Reload);
        }
        else Reload();
    }


    void Reload()                                        // 기존 Restart 의 내용을 여기로
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
