using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CoinTest
    {
		CoinControl coinControl = new CoinControl();
        // A Test behaves as an ordinary method
        [Test]
        public void StartingBalanceTest()
        {
			int balance;
            balance = CoinControl.getBalance();
			Assert.IsTrue(balance == 0);
        }

		[Test]
        public void AddBalanceTest()
        {
			int beforeAddBalance;
			int afterAddBalance;
            beforeAddBalance = CoinControl.getBalance();
			coinControl.addCoins(10);
			afterAddBalance = CoinControl.getBalance();
			Assert.IsTrue(beforeAddBalance == afterAddBalance-10);
        }

		[Test]
        public void RemoveBalanceTest()
        {
			int beforeRemoveBalance;
			int afterRemoveBalance;
            beforeRemoveBalance = CoinControl.getBalance();
			CoinControl.removeCoins(10);
			afterRemoveBalance = CoinControl.getBalance();
			Assert.IsTrue(beforeRemoveBalance == afterRemoveBalance+10);
        }

		[Test]
        public void RemoveBalanceOverAllowed()
        {
			int beforeRemoveBalance;
			int afterRemoveBalance;
            beforeRemoveBalance = CoinControl.getBalance();
			bool returnvalue = CoinControl.removeCoins(beforeRemoveBalance*2);
			afterRemoveBalance = CoinControl.getBalance();
			Assert.IsTrue(beforeRemoveBalance == afterRemoveBalance && !returnvalue);
        }
    }
}
