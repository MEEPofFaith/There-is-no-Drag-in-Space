using static UpgradesManager;

public class XpUpgrade : BaseUpgrade{
    public float gain;

    public XpUpgrade(float gain, UpgradeRarity rarity = UpgradeRarity.COOL) : base(rarity){
        this.gain = gain;

        name = "More Exp";
    }

    public override string description(){
        return "Exp Gain: +" + displayPercChange(PlayerMain.Instance.xpMult - 1, gain);
    }

    public override void Apply(){
        PlayerMain.Instance.xpMult += gain;
    }
}