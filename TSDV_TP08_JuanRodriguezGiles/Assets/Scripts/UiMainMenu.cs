using UnityEngine;
public class UiMainMenu : MonoBehaviour
{
    public void Play()
    {
        GameManager.Get().LoadGameplay();
    }
    public void Exit()
    {
        Application.Quit();
    }
}