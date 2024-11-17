using static UpgradesManager;

public class MaxSpdUpgrade : BaseUpgrade{
    public float speed;

    public MaxSpdUpgrade(float speed, UpgradeRarity rarity = UpgradeRarity.COOLEST) : base(rarity){
        this.speed = speed;

        name = "Space Breaks";
    }

    public override string description(){
        return "Max Speed: " + speed + " units/sec"
            + "\n\n...How does this even work?";
    }

    public override void Apply(){
        PlayerMain.Instance.maxSpeed = speed;
    }

    public override bool canObtain(){
        return PlayerMain.Instance.maxSpeed < 0;
    }
}