using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidarmana : MonoBehaviour
{
    public Hand hand;
    public Image fillimage;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = hand.mana;
        float fillvalue = hand.manatual - hand.customagia;
        slider.value = fillvalue;
    }
}
