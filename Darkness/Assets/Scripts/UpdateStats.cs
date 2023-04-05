using UnityEngine;
using TMPro;

public class UpdateStats : MonoBehaviour
{
    public TextMeshProUGUI m_text;

    public void UpdateStat()
    {
        string temp = m_text.text;
        int value = System.Convert.ToInt32(temp);

        if (value >= 30)
        {
            value = value + 5;
            temp = System.Convert.ToString(value);
            m_text.text = temp;
        }

        if (value <= 4)
        {
            value = value - 1;
            temp = System.Convert.ToString(value);
            m_text.text = temp;
        }
    }
}
