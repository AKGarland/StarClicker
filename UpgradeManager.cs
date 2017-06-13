using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {
    public Click click;
    public Text itemInfo;
	public Text itemQuantity;
	public Text description;
	public GameObject descriptionBox;
    public float cost;
    public float count = 0f;
    public int clickPower;
    
    public string itemName;
	public string itemDescription;

    private float baseCost;
	private bool hover = false;

    private void Start()
    {
        baseCost = cost;
		description.text = itemDescription;
    }

    void Update()
    {
		itemInfo.text = itemName + "\nCost: " + cost + "\nStars: " + clickPower + "/s";
		if (hover == false) {
			descriptionBox.SetActive (false);
			itemQuantity.text = "Owned: " + count.ToString ();
		} else if (hover == true) {
			descriptionBox.gameObject.SetActive (true);
		}
    }

    public void purchasedUpgrade()
    {
        if (click.star >= cost) {
            click.star -= cost;
            count += 1;
            click.starPerClick += clickPower;
            cost = Mathf.Round(baseCost * Mathf.Pow(1.152f, count));
        }
    }
		
	public void OnMouseEnter(){
		hover = true;
	}

	public void OnMouseExit(){
		hover = false;
	}
}
