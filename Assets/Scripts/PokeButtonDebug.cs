using TMPro;
using UnityEngine;

public class PokeButtonDebug : MonoBehaviour
{
    public TextMeshPro debugText; // <-- 3D text component

    public void OnPoke()
    {
        debugText.text = "Debug complete";
    }
}