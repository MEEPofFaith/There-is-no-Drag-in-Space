using TMPro;
using UnityEngine;

public class UpgradeCard : MonoBehaviour {
    public BaseUpgrade upgrade;
    public TMP_Text nameText;
    public TMP_Text descText;

    public void init(BaseUpgrade upgrade){
        this.upgrade = upgrade;
        this.upgrade.display(nameText, descText);
    }
    
    public void OnMouseDown() {
        upgrade.Apply();
        UpgradesManager.Instance.clear();
    }
}