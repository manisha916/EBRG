using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownCanvas : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public async void StartCountdown()
    {
        Debug.Log("GH");
        countdownText.enabled = true;

        countdownText.text = "3";
        await System.Threading.Tasks.Task.Delay(666);
        Debug.Log("GH");
        countdownText.text = "2";
        await System.Threading.Tasks.Task.Delay(666);

        countdownText.text = "1";
        await System.Threading.Tasks.Task.Delay(666);

        countdownText.enabled = false;
    }
}
