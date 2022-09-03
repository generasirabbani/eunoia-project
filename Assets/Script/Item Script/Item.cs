using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Sword,
        MagicStaff,
        HealthPotion,
        ManaPotion,
        Grass,
        Ratan,
        Wood,
        Rock,
        MagicCrystal,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
            case ItemType.MagicStaff:   return ItemAssets.Instance.mStaffSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.hPotionSprite;
            case ItemType.ManaPotion:   return ItemAssets.Instance.mPotionSprite;
            case ItemType.Grass:        return ItemAssets.Instance.grassSprite;
            case ItemType.Ratan:        return ItemAssets.Instance.ratanSprite;
            case ItemType.Wood:         return ItemAssets.Instance.woodSprite;
            case ItemType.Rock:         return ItemAssets.Instance.rockSprite;
            case ItemType.MagicCrystal: return ItemAssets.Instance.mCrystalSprite;
        }
    }

    public Color GetColor()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:        return new Color(0, 0, 0);
            case ItemType.MagicStaff:   return new Color(0, 0, 1);
            case ItemType.HealthPotion: return new Color(1, 0, 0);
            case ItemType.ManaPotion:   return new Color(0, 0, 1);
            case ItemType.Grass:        return new Color(0, 1, 0);
            case ItemType.Ratan:        return new Color(0, 1, 1);
            case ItemType.Wood:         return new Color(1, 1, 0);
            case ItemType.Rock:         return new Color(1, 0, 1);
            case ItemType.MagicCrystal: return new Color(1, 1, 1);
        }
    }
}
