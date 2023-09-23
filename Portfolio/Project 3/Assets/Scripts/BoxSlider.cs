using UnityEngine;
using UnityEngine.UI;

public class BoxSlider : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GameObject.Find("BoxSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    private void Update()
    {
        var delta = 0;
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Change slider by -1");
            delta = -1;
        } else if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Change slider by 1");
            delta = 1;
        }

        var value = slider.value;
        slider.value = value + delta;

        if (slider.value > 5)
        {
            slider.value = 5;
        }

        if (slider.value < 0)
        {
            slider.value = 0;
        }
    }
}
