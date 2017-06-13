using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

    public UpgradeManager upgradeManager;
    public float quantity;
    public float levelTotal;

	// Use this for initialization
	void Start () {
        quantity = upgradeManager.count;
        levelTotal = 25f; // TODO will need if(quantity/levelTotal => 1) {redefine levelTotal as next level from the array??} in Update to redefine this!!
	}
	
	// Update is called once per frame
	void Update () {
        quantity = upgradeManager.count;
        GetComponent<Image>().fillAmount = (quantity / levelTotal); 
	}
}
