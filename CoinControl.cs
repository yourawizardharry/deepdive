using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
	private static int coins = 0;
	private static object Lock = new object();

    // Start is called before the first frame update
    void Start()
    {
		if(PlayerPrefs.HasKey("coins")) coins =  PlayerPrefs.GetInt("coins");
		else PlayerPrefs.SetInt("coins", coins);
    }

	public static void addCoins(int amount) {
	lock (Lock) {
		coins += amount;
		}
	}

	public static bool removeCoins(int amount) {
		lock (Lock) {
			if((coins - amount) >= 0) {
				coins -= amount;
				return true;
			}
			else return false;
		}
	}

	public static int getBalance() {
		lock (Lock) {
			return coins;
		}
	}
}
