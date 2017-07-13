using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager manager;

    public UpgradeManager[] upgradeManager;
    public ItemManager[] items;

    private float loadTime;
    private Click click;                    // current total Click.star & perClick click.starPerClick
    // star per second dPerSec.StarsPerSec(): needs item.count * item.tickValue


    void Start () {
        click = FindObjectOfType<Click>( );
	}

    public void SetProgressBar(GameObject progressBar, float quantity, float levelTotal)
    {
        progressBar.GetComponent<Image>( ).fillAmount = (quantity / levelTotal);
    }
	
	public void Save () {
        BinaryFormatter binForm = new BinaryFormatter( );
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.ball");

        PlayerInfo info = new PlayerInfo( );
        info.stars = click.star;
        info.starsPerClick = click.starPerClick;
        info.timeOfSave = Time.time;

            for (int i = 0; i < items.Length; i++)
            {
                info.itemCount[i] = items[i].count;
                info.itemTickValue[i] = items[i].tickValue;
                info.itemCost[i] = items[i].cost;
            }

        for (int i = 0; i < items.Length; i++)
            {
                info.upgradeCount[i] = upgradeManager[i].count;
                info.upgradeClickPower[i] = upgradeManager[i].clickPower;
                info.upgradeCost[i] = upgradeManager[i].cost;
            }
        
        binForm.Serialize(file, info);
        file.Close( );
	}

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.ball"))
        {
            BinaryFormatter binForm = new BinaryFormatter( );
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.ball", FileMode.Open);

            PlayerInfo info = (PlayerInfo)binForm.Deserialize(file);
            file.Close( );

            click.starPerClick = info.starsPerClick;


            for (int i = 0; i < items.Length; i++)
            {
                items[i].count = info.itemCount[i];
                items[i].tickValue = info.itemTickValue[i];
                items[i].cost = info.itemCost[i];
            }
            
            for (int i = 0; i < items.Length; i++)
            {
                upgradeManager[i].count = info.upgradeCount[i];
                upgradeManager[i].clickPower = info.upgradeClickPower[i];
                upgradeManager[i].cost = info.upgradeCost[i];
            }
            loadTime = Time.time;
            click.star = info.stars + StarsSinceLoad(info.timeOfSave);
        }
    }

    float StarsSinceLoad(float time)
    {
        float addStars = 0;
        foreach (ItemManager item in items)
        {
            addStars += (item.count * item.tickValue)*(loadTime-time); 
        }
        return addStars;
    }
}

[Serializable]
class PlayerInfo
{
    public float stars;
    public int starsPerClick;

    public int[] itemTickValue = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[] itemCount = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public float[] itemCost = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public int[] upgradeClickPower = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public float[] upgradeCost = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public float[] upgradeCount = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public float timeOfSave;
}