using UnityEngine;
using TMPro;

public class UpdateStats : MonoBehaviour
{
    public TextMeshProUGUI m_text;


    public void UpdateStat(string text)
    {
        m_text.text = text;
    }
}
