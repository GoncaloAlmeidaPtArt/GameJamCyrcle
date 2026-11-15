using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
