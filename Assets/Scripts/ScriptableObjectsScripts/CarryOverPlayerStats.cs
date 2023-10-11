using UnityEngine;

[CreateAssetMenu(fileName =  "CarryOverPlayerStats", menuName =  "ScriptableObjects/GameConstants", order =  0)]
public  class CarryOverPlayerStats : ScriptableObject
{
    public int score = 0;
    public float currHealth = 0;
    public float maxHealth = 0;
    public bool loadedPreviously = false;

    private void OnEnable()
    {
        loadedPreviously = false;
        score = 0;
        currHealth = 0;
        maxHealth = 0;
    }
}
