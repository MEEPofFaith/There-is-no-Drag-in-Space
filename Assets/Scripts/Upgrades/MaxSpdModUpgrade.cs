using static UpgradesManager;

public class MaxSpdModUpgrade : BaseUpgrade{
    public float speed;

    public MaxSpdModUpgrade(float speed, UpgradeRarity rarity = UpgradeRarity.COOLEST) : base(rarity){
        this.speed = speed;

        name = "Change Max Speed";
    }

    public override string description(){
        return "Max Speed: " + numStat(speed) + " units/sec";
    }

    public override void Apply(){
        PlayerMain.Instance.maxSpeed += speed;
    }

    public override bool canObtain(){
        if(PlayerMain.Instance.maxSpeed < 0) return false;

        return speed > 0 || PlayerMain.Instance.maxSpeed > -speed + 1; //Don't allow negative max speed
    }
}