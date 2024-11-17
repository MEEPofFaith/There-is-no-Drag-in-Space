using static UpgradesManager;

public class AccelUpgrade : BaseUpgrade{
    public float accel;

    public AccelUpgrade(float accel, UpgradeRarity rarity = UpgradeRarity.COOL) : base(rarity){
        this.accel = accel;

        name = accel > 0 ? "Accelerate Faster" : "Accelerate Slower";
    }

    public override string description(){
        return "Acceleration: " + displayChange(PlayerMain.Instance.accel, accel, " units/sec^2");
    }

    public override void Apply(){
        PlayerMain.Instance.accel += accel;
    }

    public override bool canObtain(){
        return accel > 0 || PlayerMain.Instance.accel > -accel + 1; //Don't allow negative accel
    }
}