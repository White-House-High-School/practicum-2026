using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    private int startMoney = 10;

    void Start()
    {
        Money = startMoney;
    }
}
