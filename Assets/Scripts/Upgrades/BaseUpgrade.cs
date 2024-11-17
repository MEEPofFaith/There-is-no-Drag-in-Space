using System.Collections.Generic;
using TMPro;
using static UpgradesManager;

public abstract class BaseUpgrade{
    public string name = "Upgrade"; //TODO how to set?
    public UpgradeRarity rarity = UpgradeRarity.COOL;

    public BaseUpgrade(UpgradeRarity rarity){
        this.rarity = rarity;

        Upgrades.allUpgrades[(int)rarity].Add(this);
    }

    public abstract string description();

    public void display(TMP_Text nameText, TMP_Text descText){ //TODO rarity
        nameText.SetText(name);
        descText.SetText(description());
    }

    public virtual bool canObtain(){
        return true;
    }

    public abstract void Apply();

    protected string displayChange(float start, float change, string unit = ""){
        return start + unit + " -> " + (start + change) + unit;
    }

    protected string displayChange(int start, int change, string unit = ""){
        return start + unit + " -> " + (start + change) + unit;
    }

    protected string displayPercChange(float start, float change){
        return start * 100 + "% -> " + (start + change) * 100 + "%";
    }

    protected string numStat(int value){
        return (value > 0 ? "+" : "") + value;
    }

    protected string numStat(float value){
        return (value > 0 ? "+" : "") + value;
    }

    protected string percStat(float value){
        return (value > 0 ? "+" : "") + (value * 100) + "%";
    }
}