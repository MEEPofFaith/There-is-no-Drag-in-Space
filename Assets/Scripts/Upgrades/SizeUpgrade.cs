using UnityEngine;
using static UpgradesManager;

public class SizeUpgrade : BaseUpgrade{
    public float size;

    public SizeUpgrade(float size, UpgradeRarity rarity = UpgradeRarity.COOLER) : base(rarity){
        this.size = size;

        name = "Expand... Somehow";
    }

    public override string description(){
        return "Size: +" + displayPercChange(PlayerMain.Instance.sizeMod, size);
    }

    public override void Apply(){
        PlayerMain.Instance.transform.localScale += new Vector3(size, size, size);
        PlayerMain.Instance.sizeMod += size;
    }
}