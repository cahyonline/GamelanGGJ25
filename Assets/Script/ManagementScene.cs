using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManagementScene : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Gameplay2");
    }

       public void Retry1()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
