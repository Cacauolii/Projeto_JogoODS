using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    public int totalWood;
    public int carrots;
    public float currentWater;
    public int fishes;

    [Header("Limits")]
    public float waterLimit = 50;
    public float carrotsLimit = 5;
    public float woodLimit = 10;
    public float fishesLimits = 3f;

    public void WaterLimit(float water)
    {
        if (currentWater < waterLimit)
        {
            currentWater += water;
        }


    }

}
