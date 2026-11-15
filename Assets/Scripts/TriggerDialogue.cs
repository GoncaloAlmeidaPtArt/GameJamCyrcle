using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    private void OnTriggerEnter(Collider other) 
    {
        dialogue.SetActive(true);
    }

    private void OnTriggerExit(Collider other) 
    {
        dialogue.SetActive(false);
    }
}
