using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider hpSlider;

    public void SetHUD(Unit _unit)
    {
        nameText.text = _unit.unitName;
        levelText.text = "Lvl: " + _unit.unitLevel;
        hpSlider.maxValue = _unit.maxHP;
        hpSlider.value = _unit.currentHP;
    }

    public void SetHP(int _hp)
    {
        hpSlider.value = _hp;
    }

}
