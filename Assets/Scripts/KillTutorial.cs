using TMPro;
using UnityEngine;

public class KillTutorial : MonoBehaviour
{
    [SerializeField] private GameObject Tutorial;

    public void OnPoke()
    {
        if (Tutorial != null)
        {
            Destroy(Tutorial);
        }
    }
}