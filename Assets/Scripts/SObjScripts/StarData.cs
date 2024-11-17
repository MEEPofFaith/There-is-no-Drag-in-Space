using UnityEngine;

[CreateAssetMenu(fileName = "StarXp", menuName = "StarXp", order = 1)]
public class StarData : ScriptableObject {
    public float xp = 1;
    public float size = 1;
    public float expireTime = -1;
}