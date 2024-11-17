using static UpgradesManager;

public class SpawnRateUpgrade : BaseUpgrade{
    public float rate;

    public SpawnRateUpgrade(float rate, UpgradeRarity rarity = UpgradeRarity.COOLER) : base(rarity){
        this.rate = rate;

        name = "Faster Stars";
    }

    public override string description(){
        return "Spawn Rate: " + displayChange(StarSpawner.Instance.spawnDelay, -rate, " sec");
    }

    public override void Apply(){
        StarSpawner.Instance.spawnDelay -= rate;
    }

    public override bool canObtain(){
        return StarSpawner.Instance.spawnDelay > rate + 0.1f;
    }
}