using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform player;
    public ScoreManager scoreManager;

    public int amount = 1;

    private void Update()
    {
        if (Vector2.SqrMagnitude(transform.position - player.position) < 0.36f)
        {
            scoreManager.AddScore(amount);
            float x = Random.Range(-2.5f, 2.5f);
            float y = Random.Range(-3.5f, 3.5f);
            transform.position = new Vector3(x, y, 0f);
        }
    }
}
