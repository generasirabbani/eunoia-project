using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite swordSprite;
    public Sprite mStaffSprite;
    public Sprite hPotionSprite;
    public Sprite mPotionSprite;
    public Sprite grassSprite;
    public Sprite ratanSprite;
    public Sprite woodSprite;
    public Sprite rockSprite;
    public Sprite mCrystalSprite;
}
