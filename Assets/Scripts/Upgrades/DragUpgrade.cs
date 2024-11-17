using static UpgradesManager;

public class DragUpgrade : BaseUpgrade{
    public float drag;

    public DragUpgrade(float drag, UpgradeRarity rarity = UpgradeRarity.COOLEREST) : base(rarity){
        this.drag = drag;

        name = "Anger the Scientists";
    }

    public override string description(){
        return "Magically gain drag."
            + "\nDrag: " + displayPercChange(PlayerMain.Instance.drag, drag);
    }

    public override void Apply(){
        PlayerMain.Instance.drag += drag;
    }

    public override bool canObtain(){
        return PlayerMain.Instance.drag + drag <= 0.8f; //Limit drag
    }
}