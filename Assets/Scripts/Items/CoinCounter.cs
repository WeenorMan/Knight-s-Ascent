using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text coinText;
    public int coinCount = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Score: " + coinCount.ToString();
    }

    public void IncreaseCoins(int v)
    {
        coinCount += v;
        coinText.text = "Score: " + coinCount.ToString();
    }

   
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
