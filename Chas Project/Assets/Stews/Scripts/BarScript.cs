using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    [SerializeField]
    private Image content;
    [SerializeField]
    private string barName;
    [SerializeField]
    private Text valueText;

    private float fillAmount;

    public float MaxValue { get; set; }

    public float Value {
        set {
            fillAmount = percantage(value,MaxValue);
            valueText.text = barName + (int)value;
        }
    }

	void Update () {
        UpdateBar();
	}

    void UpdateBar() {
        if (fillAmount !=content.fillAmount) {
            content.fillAmount = fillAmount;
        }        
    }
    float percantage(float value,float max) {
        return (value / max);
    }
}
