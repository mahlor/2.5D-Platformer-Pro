using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]private Text coinCounter = null;

    public void UpdateCoinCounter(int coinCount)
    {
        coinCounter.text = "Coins: " + coinCount.ToString();
    }
}
