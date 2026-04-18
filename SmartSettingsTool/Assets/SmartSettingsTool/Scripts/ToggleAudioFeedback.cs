using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleAudioFeedback : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioManager audioManager;  // Link to your AudioManager
    public Toggle toggle;  // Link to the Toggle here

    // Called when the pointer enters the Toggle (hover over)
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.PlayHoverSound();  // Play hover sound when mouse enters
    }

    // Called when the pointer exits the Toggle (mouse leaves)
    public void OnPointerExit(PointerEventData eventData)
    {
        // You can stop the sound here or leave it empty if not needed
        // If you want to play another sound when the mouse leaves, add that functionality here
    }

    // Called when the Toggle value changes (checked/unchecked)
    public void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            audioManager.PlayClickSound();  // Play click sound when toggled on
        }
        else
        {
            audioManager.PlayClickSound();  // Play click sound when toggled off
        }
    }

    void Start()
    {
        // Make sure the toggle changes call the audioManager when changed
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }
}