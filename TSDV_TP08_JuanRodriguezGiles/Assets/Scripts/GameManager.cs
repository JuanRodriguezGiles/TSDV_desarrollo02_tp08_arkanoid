using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region INSTANCE
    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    public int hp = 3;
    public int score;
    public int highScore;
    void OnEnable()
    {
        Ball.onBallTouchBottom += RemoveHp;
        Ball.onBallTouchBottom += CheckGameOver;
        Brick.onBrickDestroyed += AddScore;

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    void RemoveHp()
    {
        hp--;
    }
    void AddScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    void CheckGameOver()
    {
        if (hp == 0)
        {
            LoadGameOver();
        }
    }
    public void LoadGameplay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}