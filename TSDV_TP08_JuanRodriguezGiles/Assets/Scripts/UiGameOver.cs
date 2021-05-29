using TMPro;
using UnityEngine;
public class UiGameOver : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    void Start()
    {
        score.text = "Score " + GameManager.Get().score;
        highScore.text = "High Score " + GameManager.Get().highScore;
    }
}