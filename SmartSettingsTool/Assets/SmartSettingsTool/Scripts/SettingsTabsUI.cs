using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsTabsUI : MonoBehaviour
{
    [System.Serializable]
    public class Tab
    {
        public string tabName;
        public Button button;
        public Image buttonImage;
        public TextMeshProUGUI buttonText;
        public GameObject panel;
    }

    [Header("Tabs")]
    public Tab[] tabs;

    [Header("Selected Tab Style")]
    public Color selectedButtonColor = new Color(0.56f, 0.58f, 0.64f, 1f);   // lichtblauw/paarsig
    public Color selectedTextColor = Color.white;

    [Header("Unselected Tab Style")]
    public Color unselectedButtonColor = new Color(0.45f, 0.46f, 0.51f, 1f); // donkerder grijs-paars
    public Color unselectedTextColor = new Color(0.73f, 0.73f, 0.73f, 1f);

    [Header("Start Tab")]
    public int startTabIndex = 0;

    private void Start()
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            int index = i;
            tabs[i].button.onClick.AddListener(() => SelectTab(index));
        }

        SelectTab(startTabIndex);
    }

    public void SelectTab(int index)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            bool isSelected = i == index;

            if (tabs[i].panel != null)
                tabs[i].panel.SetActive(isSelected);

            if (tabs[i].buttonImage != null)
                tabs[i].buttonImage.color = isSelected ? selectedButtonColor : unselectedButtonColor;

            if (tabs[i].buttonText != null)
                tabs[i].buttonText.color = isSelected ? selectedTextColor : unselectedTextColor;
        }
    }
}