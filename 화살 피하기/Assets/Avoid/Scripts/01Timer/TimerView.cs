using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    public TextMeshProUGUI _timerText;

    public void SetTimerText(float value)
    {
        _timerText.text = value.ToString("f2");
    }
}
