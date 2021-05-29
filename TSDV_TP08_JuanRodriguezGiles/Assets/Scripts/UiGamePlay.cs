using TMPro;
using UnityEngine;
public class UiGamePlay : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    public TMP_Text hp;
    void OnEnable()
    {
        Ball.onBallTouchBottom += UpdateHp;
        GameManager.onScoreChange += UpdateScores;
    }
    void Start()
    {
        UpdateHp();
        UpdateScores();
    }
    void UpdateHp()
    {
        hp.text = GameManager.Get().hp.ToString();
    }
    void UpdateScores()
    {
        score.text = GameManager.Get().score.ToString();
        highScore.text = GameManager.Get().highScore.ToString();
    }
}
