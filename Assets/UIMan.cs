using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class UIMan : MonoBehaviour
{
    public Button PlayButton, QuitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayButton.onClick.AddListener(Play);
        QuitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
