using System.Collections;
using System.Collections.Generic;
using static UpgradesManager;

public class Upgrades{
    public static List<BaseUpgrade>[] allUpgrades;

    public static BaseUpgrade

    //Cool
    accelUp, accelDown, rotAccelUp, rotAccelDown, xpUp,
    
    //Cooler
    sizeUp, maxStarsUp, starRateUp,
    
    //Coolest
    dragUp,
    
    //Coolerest
    maxSpeed, maxSpeedUp, maxSpeedDown;

    public static void load(){
        int rarities = System.Enum.GetValues(typeof(UpgradeRarity)).Length;
        allUpgrades = new List<BaseUpgrade>[rarities];
        for(int i = 0; i < rarities; i++){
            allUpgrades[i] = new List<BaseUpgrade>();
        }

        //Cool
        accelUp = new AccelUpgrade(0.5f);
        accelDown = new AccelUpgrade(-0.5f);
        rotAccelUp = new RotAccelUpgrade(5f);
        rotAccelDown = new RotAccelUpgrade(-5f);
        xpUp = new XpUpgrade(0.25f);

        //Cooler
        sizeUp = new SizeUpgrade(0.2f);
        starRateUp = new SpawnRateUpgrade(0.5f);
        maxStarsUp = new SpawnLimitUpgrade(2);

        //Coolest
        maxSpeed = new MaxSpdUpgrade(10f);
        maxSpeedUp = new MaxSpdModUpgrade(1f);
        maxSpeedDown = new MaxSpdModUpgrade(-1f);

        //Coolerest
        dragUp = new DragUpgrade(0.05f);
    }
}