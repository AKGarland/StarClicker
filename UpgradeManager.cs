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
    public GameObject progress;
    public float cost;
    public float count = 0f;
    public int clickPower;
    public string itemName;
	public string itemDescription;

    private float baseCost;
    private int basePower;
	private bool hover = false;
    private GameManager gameManager;
    private float[] allLevelTotals = { 25, 10, 250, 500, 777, 1000, 1250, 1337, 1500, 1750, 2000, 2250, 2500, 2750, 3000, 3250, 3500, 3750, 4000 };
    private int level = 0;
    private Transform itemLevel;

    private void Start()
    {
        baseCost = cost;
		description.text = itemDescription;
        gameManager = FindObjectOfType<GameManager>( );
        itemLevel = progress.transform.Find("ItemLevel");
        basePower = (int)clickPower;
    }

    void Update()
    {
        level = 0;
        for (int i = 0; i<allLevelTotals.Length-1; i++)
        {
            if (count > allLevelTotals[level])
            {
                level++;
                float myLevel = (float)level;
                clickPower = (basePower - (1/basePower)) * (level+1);
            }
        }
        gameManager.SetProgressBar(progress, count, allLevelTotals[level]); // Second argument: will need if(quantity/levelTotal => 1) {redefine levelTotal as next level from the array??} in Update to redefine this!!
        if (itemLevel != null)
        {
            print("Child text found." );
            itemLevel.GetComponent<Text>( ).text = level.ToString( );
        }
        itemInfo.text = itemName + "\nCost: " + cost + "\nStars: " + clickPower + "/click";
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
