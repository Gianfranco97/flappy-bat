using UnityEngine;

public class ClonePreview : MonoBehaviour
{
    [SerializeField] SkinManager skinManager;
    [SerializeField] Sprite skinBasic;
    [SerializeField] Sprite skinFire;
    [SerializeField] Sprite skinAlbino;
    [SerializeField] Sprite skinZombie;
    [SerializeField] Sprite skinVampire;

    private void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        switch (skinManager.selectedSkin)
        {
            case SkinName.Basic:
                spriteRenderer.sprite = skinBasic;
                break;
            case SkinName.Fire:
                spriteRenderer.sprite = skinFire;
                break;
            case SkinName.Albino:
                spriteRenderer.sprite = skinAlbino;
                break;
            case SkinName.Zombie:
                spriteRenderer.sprite = skinZombie;
                break;
            case SkinName.Vampire:
                spriteRenderer.sprite = skinVampire;
                break;
        }
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
