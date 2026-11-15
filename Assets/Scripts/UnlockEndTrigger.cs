using UnityEngine;

public class UnlockEndTrigger : MonoBehaviour
{
    [SerializeField] private GameObject toActivate;
    [SerializeField] private GameObject toDeactivate;
    private bool _ended;

    private void Start()
    {
        _ended = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_ended)
        {
            _ended = true;
            toDeactivate.SetActive(false);
            toActivate.SetActive(true);
        }
    }
}
