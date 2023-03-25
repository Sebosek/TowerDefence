using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _game;

    public void StartGame()
    {
        Debug.Log($"Gonna log game scene {_game}");
        SceneManager.LoadScene(_game);
    }

    public void ExitGame()
    {
        Debug.Log("Application is gonna be quit");
        Application.Quit();
    }
}
