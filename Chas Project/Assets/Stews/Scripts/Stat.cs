using System;
using UnityEngine;

[Serializable]
public class Stat {
    [SerializeField]
    private BarScript bar;
    [SerializeField]
    private float maxValue;
    [SerializeField]
    private float currentValue;

    public float CurrentValue {
        get {
            return currentValue;
        }
        set {

            currentValue = Mathf.Clamp(value, 0, MaxValue);
            if (bar) {
                bar.Value = currentValue;
            }
        }
    }

    public float MaxValue {
        get {
            return maxValue;
        }

        set {
            maxValue = value;
            if (bar) {
                bar.MaxValue = maxValue;
            }
        }
    }
    public void Initialize() {
        this.MaxValue = maxValue;
        this.CurrentValue = currentValue;
    }

}
