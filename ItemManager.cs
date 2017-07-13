using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public Text itemInfo;
	public Text itemQuantity;
	public Text description;
	public GameObject descriptionBox;
    public GameObject progress;
    public float cost;
    public int tickValue;
    public int count;
    public string itemName;
	public string itemDescription;

    private float baseCost;
	private Click click;
	private bool hover = false;
    private GameManager gameManager;


    private void Start()
    {
        baseCost = cost;
		description.text = itemDescription;	
		click = FindObjectOfType<Click>();
        gameManager = FindObjectOfType<GameManager>( );
    }

    private void Update()
    {
        gameManager.SetProgressBar(progress, count, 25f); // Second argument: will need if(quantity/levelTotal => 1) {redefine levelTotal as next level from the array??} in Update to redefine this!!
        itemInfo.text = itemName + "\nCost: " + cost + "\nStars: " + tickValue + "/s";
		if (hover == false) {
			descriptionBox.SetActive (false);
			itemQuantity.text = "Owned: " + count.ToString ();
		} else if (hover == true) {
			descriptionBox.gameObject.SetActive (true);
		}
    }

    public void PurchasedItem() {
        if (click.star >= cost) {
            click.star -= cost;
            count += 1;
            cost = Mathf.Round(baseCost*Mathf.Pow(1.155f,count));
        }
    }

	public void OnMouseEnter(){
		hover = true;
	}

	public void OnMouseExit(){
		hover = false;
	}
}
