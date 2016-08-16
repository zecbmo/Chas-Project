using UnityEngine;
using System.Collections;

public class GetVoiceInput : MonoBehaviour {

    public GameObject audioInputObject;
    public float threshold = 1.0f;
    MicrophoneInput micIn;

    public int sample_size = 100;
    private float[] max_loudness;
    private int array_count = 0;
    private float average_loudness = 0;
    private float updated_threshold;
    public bool threshold_updated = false;

    void Start()
    {
    
        micIn = (MicrophoneInput)audioInputObject.GetComponent("MicrophoneInput");
        updated_threshold = threshold;
        max_loudness = new float[sample_size];
}

    void Update()
    {
        float l = micIn.loudness;
        if (l > updated_threshold)
        {
            //print("you are speaking");
        }
        else
        {
           // print("not speaking");
        }
    }

    //needs testing
    public void CalculateThreshold()
    {
        if (array_count < sample_size-1)
        {
            max_loudness[array_count] = micIn.loudness;
        }
        else
        {
            array_count = 0;
            float average = 0;
            foreach (float n in max_loudness)
            {
                average += n;
            }
            average_loudness = average / (float)sample_size;
            updated_threshold = average_loudness + threshold;
            threshold_updated = true; //signal the end of the function
        }
            
    }
}
