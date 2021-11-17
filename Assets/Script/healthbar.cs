using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Player player;
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
        slider.maxValue = player.vidafull;
        float fillvalue = player.health - player.custovida;
        slider.value = fillvalue;
    }
   
}
