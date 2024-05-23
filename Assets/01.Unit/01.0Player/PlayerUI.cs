using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image expSlider;
    [SerializeField] private Image hpSlider;
    [SerializeField] private Image manaSlider;

    private void Start()
    {
        HpManager.Instance.OnChangeHp += (hp, maxHp) => HpSlider(hp, maxHp);
        LevelSystem.Instance.OnChangeExp += (exp, maxExp) => ExpSlider(exp, maxExp);
    }

    public void ExpSlider(float exp, float maxExp)
    {
        expSlider.fillAmount = exp / maxExp;
    }

    public void HpSlider(int hp, int maxHp)
    {
        hpSlider.fillAmount = (float)hp / maxHp;
    }

    public void ManaSlider()
    {

    }
}
