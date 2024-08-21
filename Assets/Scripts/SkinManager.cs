using System;
using System.Collections.Generic;
using UnityEngine;

public enum SkinName { Basic, Fire, Albino, Vampire, Zombie }

public class SkinState
{
    public bool acquired { get; set; }
    public bool selected { get; set; }
}

public class SkinManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject skinMenuModal;
    [SerializeField] Animator playerAnimator;
    [SerializeField] RuntimeAnimatorController skinBasic;
    [SerializeField] RuntimeAnimatorController skinFire;
    [SerializeField] RuntimeAnimatorController skinAlbino;
    [SerializeField] RuntimeAnimatorController skinZombie;
    [SerializeField] RuntimeAnimatorController skinVampire;
    [SerializeField] GameObject insufficientRubiesModal;
    public SkinName selectedSkin;
    public Dictionary<SkinName, SkinState> skins = new Dictionary<SkinName, SkinState>()
    {
        { SkinName.Basic, new SkinState() { acquired = true, selected = true }},
        { SkinName.Fire, new SkinState() { acquired = false, selected = false }},
        { SkinName.Albino, new SkinState() { acquired = false, selected = false }},
        { SkinName.Zombie, new SkinState() { acquired = false, selected = false }},
        { SkinName.Vampire, new SkinState() { acquired = false, selected = false }},
    };

    private void Start()
    {
        string selectedSkin = PlayerPrefs.GetString("SelectedSkin", "Basic");
        int FireSkinAcquired = PlayerPrefs.GetInt("FireSkinAcquired", 0);
        int AlbinoSkinAcquired = PlayerPrefs.GetInt("AlbinoSkinAcquired", 0);
        int ZombieSkinAcquired = PlayerPrefs.GetInt("ZombieSkinAcquired", 0);
        int VampireSkinAcquired = PlayerPrefs.GetInt("VampireSkinAcquired", 0);

        skins[SkinName.Fire].acquired = FireSkinAcquired == 1;
        skins[SkinName.Albino].acquired = AlbinoSkinAcquired == 1;
        skins[SkinName.Zombie].acquired = ZombieSkinAcquired == 1;
        skins[SkinName.Vampire].acquired = VampireSkinAcquired == 1;

        selectSkin((SkinName)Enum.Parse(typeof(SkinName), selectedSkin));
    }

    public void closeMenu()
    {
        skinMenuModal.SetActive(false);
    }

    public void openMenu()
    {
        skinMenuModal.SetActive(true);
    }

    public void selectSkin(SkinName skin)
    {
        foreach (SkinName skinName in skins.Keys)
        {
            skins[skinName].selected = skinName == skin;
        }

        selectedSkin = skin;
        PlayerPrefs.SetString("SelectedSkin", skin.ToString());

        switch (skin)
        {
            case SkinName.Basic:
                playerAnimator.runtimeAnimatorController = skinBasic;
                break;
            case SkinName.Fire:
                playerAnimator.runtimeAnimatorController = skinFire;
                break;
            case SkinName.Albino:
                playerAnimator.runtimeAnimatorController = skinAlbino;
                break;
            case SkinName.Zombie:
                playerAnimator.runtimeAnimatorController = skinZombie;
                break;
            case SkinName.Vampire:
                playerAnimator.runtimeAnimatorController = skinVampire;
                break;
            default:
                playerAnimator.runtimeAnimatorController = skinBasic;
                break;
        }
    }

    public void changeSkin(SkinName skin)
    {
        if (!skins[skin].acquired)
        {
            if (gameManager.rubiesQuantity < 6)
            {
                openInsufficientRubies();
                return;
            }

            gameManager.ChangeRubiesQuantity(-6);
            skins[skin].acquired = true;
        };

        PlayerPrefs.SetInt(skin + "SkinAcquired", 1);
        selectSkin(skin);
    }

    public void openInsufficientRubies()
    {
        insufficientRubiesModal.SetActive(true);
    }

    public void closeInsufficientRubies()
    {
        insufficientRubiesModal.SetActive(false);
    }
}
