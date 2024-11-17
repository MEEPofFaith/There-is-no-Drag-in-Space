using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradesManager : MonoBehaviour{
    public static UpgradesManager Instance;

    public GameObject cardPrefab;
    public int level;
    private int queued;
    private bool open;
    public float cardOffset = 4.5f;

    private GameObject[] upgradeCards = new GameObject[3];

    private void Awake() {
        if(Instance != null) Debug.LogError("Excuse me there is supposed to only be one UpgradesManager what.");
        Instance = this;
    }

    private void Start() {
        Upgrades.load();
        
        for(int i = 0; i < 3; i++){
            GameObject card = Instantiate(cardPrefab, transform.position + Vector3.right * (i - 1) * cardOffset, transform.rotation);
            card.SetActive(false);
            upgradeCards[i] = card;
        }
    }

    public void display() {
        if(queued == 0 || open) return;
        open = true;
        level++;

        for(int i = 0; i < 3; i++){
            GameObject card = upgradeCards[i];
            card.GetComponent<UpgradeCard>().init(randomUpgrade(i));
            card.SetActive(true);
        }
    }

    public void clear(){
        for(int i = 0; i < 3; i++){
            upgradeCards[i].SetActive(false);
        }
        open = false;
        queued--;

        display();
    }

    public void queueUpgrade(){
        queued++;
    }

    public bool isOpen(){
        return open;
    }

    private BaseUpgrade randomUpgrade(int card){
        BaseUpgrade upgrade = randomUpgradeRarity(randomRarity(), card);
        if(upgrade == null) upgrade = randomUpgradeRarity(UpgradeRarity.COOL, card); //Fallback to cool
        return upgrade;
    }

    private BaseUpgrade randomUpgradeRarity(UpgradeRarity rarity, int card){
        List<BaseUpgrade> list = new List<BaseUpgrade>(Upgrades.allUpgrades[(int)rarity]);
        BaseUpgrade upgrade = list[Random.Range(0, list.Count)];
        while(!canObtain(upgrade, card)){
            list.Remove(upgrade);
            if(list.Count == 0) return null; //Just in case
            upgrade = list[Random.Range(0, list.Count)];
        }
        return upgrade;
    }

    private bool canObtain(BaseUpgrade upgrade, int card){ //Do not offer dupes
        if(!upgrade.canObtain()) return false;

        for(int i = 0; i < card; i++){
            if(upgradeCards[i].GetComponent<UpgradeCard>().upgrade == upgrade) return false;
        }

        return true;
    }

    private UpgradeRarity randomRarity(){
        float rand = Random.Range(0, 100);
        if(rand > 40){ //60% cool
            return UpgradeRarity.COOL;
        }else if(rand > 15){ //25% cooler
            return UpgradeRarity.COOLER;
        }else if(rand > 5){ //10% coolest
            return UpgradeRarity.COOLEST;
        }
        return UpgradeRarity.COOLEREST; //5% coolerest
    }

    public enum UpgradeRarity{
        COOL, COOLER, COOLEST, COOLEREST
    }
}
