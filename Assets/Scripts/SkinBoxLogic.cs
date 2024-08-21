using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SkinBoxLogic : MonoBehaviour
{
    Color selectedBackground = new Color(1, 1, 1, 1);
    Color selectedTitleBackground = new Color(0.21f, 0.21f, 0.21f, 0.5f);
    Color unselectedBackground = new Color(0.52f, 0.52f, 0.52f, 1);
    Color unselectedTitleBackground = new Color(1, 1, 1, 0.5f);
    Color unAcquiredBackground = new Color(0.58f, 0.73f, 0.7f, 1);

    [SerializeField] private SkinName skinName;
    [SerializeField] private SkinManager skinManager;
    [SerializeField] private Sprite sprite;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject questionMark;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject titleBackground;
    [SerializeField] private GameObject rubyIcon;
    [SerializeField] private Image background;
    
    private void validateSkinValues()
    {
        if (skinManager.skins[skinName].acquired)
        {
            image.GetComponent<Image>().sprite = sprite;
            questionMark.SetActive(false);
            title.GetComponent<TextMeshProUGUI>().text = skinName.ToString();
            rubyIcon.SetActive(false);

            if (skinManager.skins[skinName].selected)
            {
                image.GetComponent<Outline>().enabled = true;
                titleBackground.GetComponent<Image>().color = selectedTitleBackground;
                background.color = selectedBackground;
            }
            else
            {
                image.GetComponent<Outline>().enabled = false;
                titleBackground.GetComponent<Image>().color = unselectedTitleBackground;
                background.color = unselectedBackground;
            }
        }
        else
        {
            background.color = unAcquiredBackground;
        }
    }

    public void selectSkin()
    {
        skinManager.changeSkin(skinName);
    }

    void Start()
    {
        validateSkinValues();
    }

    void Update()
    {
        validateSkinValues();
    }
}
