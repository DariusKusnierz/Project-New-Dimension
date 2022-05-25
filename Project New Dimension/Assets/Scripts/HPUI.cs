using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField]
    HP PlayerHP;
    Slider slider;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        Refresh(); 

        PlayerHP.OnHealthChange += Refresh;
    }
    void Refresh()
    {
        slider.value = PlayerHP.GetValueHP();
    }
}
