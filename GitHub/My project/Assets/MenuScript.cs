using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartButton()
    {
        SceneManager.LoadScene("Collaboration Project");
    }

    public void OptionButton()
    {

    }

    public void QuitButton()
    {
        Debug.Log("Click recognised.");
        Application.Quit();
    }
}
