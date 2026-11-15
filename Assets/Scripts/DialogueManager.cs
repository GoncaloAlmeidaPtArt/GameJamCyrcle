using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueBox;
    [SerializeField] private TextMeshProUGUI nameBox;
    
    public void SetDialogue(string text)
    {
        dialogueBox.text = text;
    }

    public void SetName(string text)
    {
        nameBox.text = text;
    }

    public void NextDialogueBox(GameObject newBox)
    {
        gameObject.SetActive(false);
        newBox.SetActive(true);
    }

    public void EndChat()
    {
        gameObject.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
