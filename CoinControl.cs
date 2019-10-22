using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinControl : MonoBehaviour
{
	private static int coins = 0;
	private static object Lock = new object();
    public Text coinCounter;

    // Start is called before the first frame update
    void Start()
    {
		if(PlayerPrefs.HasKey("coins")) coins =  PlayerPrefs.GetInt("coins");
		else PlayerPrefs.SetInt("coins", coins);
    }

	public void addCoins(int amount) {
	lock (Lock) {
		coins += amount;
		}
	}

	public void removeCoins(int amount) {
		lock (Lock) {
			if((coins - amount) >= 0) {
				coins -= amount;
				//return true;
			}
			//else return false;
		}
	}

	public static int getBalance() {
		lock (Lock) {
			return coins;
		}
	}
    public void Update()
    {
        coinCounter.text = coins + " G";
    }
}
