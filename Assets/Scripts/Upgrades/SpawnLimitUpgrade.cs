using static UpgradesManager;

public class SpawnLimitUpgrade : BaseUpgrade{
    public int stars;

    public SpawnLimitUpgrade(int stars, UpgradeRarity rarity = UpgradeRarity.COOLER) : base(rarity){
        this.stars = stars;

        name = "More Stars";
    }

    public override string description(){
        return "Star Limit: " + displayChange(StarSpawner.Instance.maxStars, stars);
    }

    public override void Apply(){
        StarSpawner.Instance.maxStars += stars;
    }
}