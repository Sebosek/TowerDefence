using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void HandleReloadScene()
    {
        var name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
}
