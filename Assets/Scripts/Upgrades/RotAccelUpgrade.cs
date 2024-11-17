using static UpgradesManager;

public class RotAccelUpgrade : BaseUpgrade{
    public float accel;

    public RotAccelUpgrade(float accel, UpgradeRarity rarity = UpgradeRarity.COOL) : base(rarity){
        this.accel = accel;

        name = accel > 0 ? "Spin Faster" : "Spin Slower";
    }

    public override string description(){
        return "Acceleration: " + displayChange(PlayerMain.Instance.rotAccel, accel, " deg/sec^2");
    }

    public override void Apply(){
        PlayerMain.Instance.rotAccel += accel;
    }

    public override bool canObtain(){
        return accel > 0 || PlayerMain.Instance.rotAccel > -accel + 1; //Don't allow negative accel
    }
}