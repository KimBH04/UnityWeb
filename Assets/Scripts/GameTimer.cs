using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 30f;
    public TMP_Text timeText;
    public ScoreManager scoreManager;

    private void Update()
    {
        timeLimit -= Time.deltaTime;
        timeText.text = Mathf.CeilToInt(timeLimit) + "s";
        if (timeLimit <= 0f)
        {
            scoreManager.GameOver();
            enabled = false;
        }
    }
}