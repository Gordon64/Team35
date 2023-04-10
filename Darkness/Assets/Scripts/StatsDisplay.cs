using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatsDisplay : MonoBehaviour
{
    // public TextMeshProUGUI StatName;
    // public TextMeshProUGUI StatVal;

    // public void OnValidate(){
    //     TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
    //     StatName = texts[0];
    //     StatVal = texts[1];
    // }

    public Bandit ourBandit;

    public TMP_Text healthStat;
    public TMP_Text speedStat;
    public TMP_Text jumpStat;

    //this value isn't tied to the bandit, so it currently useless
    public TMP_Text energyStat;

    void Start(){
        updateEachStat();
    }

    void updateEachStat(){
        healthStat.text = ourBandit.health.ToString();
        speedStat.text = ourBandit.m_speed.ToString();
        jumpStat.text = ourBandit.m_jumpForce.ToString();
    }
}