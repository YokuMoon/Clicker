using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickMoney : MonoBehaviour
{

    public int moneyAdd = 0;
    public int upgradeCost = 0;
    public int level = 0;
    public int total = 0;

    public GameObject tapMoney;
    public GameObject tapUpgrade;
    public GameObject lvlIndicator;
    public GameObject totalIndicator;
    public GameObject money;

    private TextMeshProUGUI tapMoneyText;
    private TextMeshProUGUI tapUpgradeText;
    private TextMeshProUGUI lvlIndicatorText;
    private TextMeshProUGUI totalIndicatorText;

    // public SpriteRenderer rend;
    Color conditionRest;
    Color conditionGetMoney;

    void Start()
    {
        tapMoneyText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        tapMoneyText.text = "+" + moneyAdd;

        totalIndicatorText = totalIndicator.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        totalIndicatorText.text = total.ToString();

        tapUpgrade.GetComponent<Image>().color = new Color(255, 255, 255);
        tapUpgradeText = tapUpgrade.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        tapUpgradeText.text = "Upgrade " + upgradeCost.ToString();

        lvlIndicatorText = lvlIndicator.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        lvlIndicatorText.text = "LV " + level.ToString();

        conditionRest = gameObject.GetComponent<Renderer>().material.color;
        conditionGetMoney = new Color(0, 255, 0);
    }

    void OnMouseDown() {
        Instantiate(money, new Vector3(gameObject.transform.position.x, gameObject.transform.position.x, gameObject.transform.position.z), Quaternion.identity);


        gameObject.GetComponent<Renderer>().material.color = conditionGetMoney;
        total += moneyAdd;
        totalIndicatorText.text = total.ToString();

        if (total >= upgradeCost) {
            tapUpgrade.GetComponent<Image>().color = new Color(0, 255, 0);
        }
    }

    void OnMouseUp() {
        gameObject.GetComponent<Renderer>().material.color = conditionRest;
    }

    public void upgradeButtonClick () {
        if (total >= upgradeCost) {
            total -= upgradeCost;
            totalIndicatorText.text = total.ToString();
            upgradeCost *= 2;
            moneyAdd += 10;
            tapMoneyText.text = "+" + moneyAdd;
            tapUpgradeText.text = "Upgrade " + upgradeCost.ToString();

            level += 1;
            lvlIndicatorText.text = "LV " + level.ToString();

            if (total >= upgradeCost) {
                tapUpgrade.GetComponent<Image>().color = new Color(0, 255, 0);
            } else {
                tapUpgrade.GetComponent<Image>().color = new Color(255, 255, 255);
            }
        }
    }
}
