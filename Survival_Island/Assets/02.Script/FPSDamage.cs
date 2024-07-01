using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDamage : MonoBehaviour
{

    public Image HPBar;
    public Text HPText;
    public int HP = 0;
    public int MAX_HP = 100;
    public string attackTag_sk = "ATTACK_SK";
    public string attackTag_mon = "ATTACK_MON";
    public string attackTag_zom = "ATTACK_ZOM";
    void Start()
    {

        HP = MAX_HP;
        HPBar.color = Color.green;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(attackTag_sk))
            HP_Info();

        if (other.gameObject.CompareTag(attackTag_mon))
            HP_Info();

        if(other.gameObject.CompareTag(attackTag_zom))
            HP_Info();
    }

    private void HP_Info()
    {
        HP -= 15;
        HPBar.fillAmount = (float)HP / (float)MAX_HP;

        HPText.text = $"<color=#ff0000>HP</color>: {HP.ToString()}";

    }

    void Update()
    {

    }
}
