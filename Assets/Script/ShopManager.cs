using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public List<Button> buttons;
    public List<TextMeshProUGUI> buttonTexts;
    private Button currentSelection;
    public void OnButtonClick(Button clickedButton)
    {
        SoundManager.inst.PlaySound(SoundName.s2);

        if (currentSelection != null)
        {
            currentSelection.interactable = true;
            int previousIndex = buttons.IndexOf(currentSelection);
            buttonTexts[previousIndex].text = "Select";
        }


        currentSelection = clickedButton;
        currentSelection.interactable = false;
        int currentIndex = buttons.IndexOf(currentSelection);
        buttonTexts[currentIndex].text = "Selected";
    }
}
