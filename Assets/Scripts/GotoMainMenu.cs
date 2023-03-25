using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMainMenu : MonoBehaviour
{
    public void HandleGotoMainMenu()
    {
        SceneManager.LoadScene("Scenes/MenuScene");
    }
}
