using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMSyncer : MonoBehaviour {

    static public float t = 0.0f;
    static public float BPM = 120.0f;

    static public float[] intarvalArray = {0.5f, 0.5f, 0.5f, 0.5f};
    static public int count = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        t += Time.deltaTime;
        if(t > 5.0f) this.gameObject.SetActive(false);

        CalculateBPM();
        
    }

    void CalculateBPM() {

        float sum = 0.0f;

        for(int i = 0; i < intarvalArray.Length; i++) {
            sum += intarvalArray[i];
        }

        float ave = sum / (float)intarvalArray.Length;

        BPM = 60 / ave;

    }

    static public void ResetTime() {

        count++;
        if(count >= intarvalArray.Length) {
            count = 0;
        } 

        intarvalArray[count] = t;

        t = 0.0f;
    }

    // private void OnGUI() {
    //     GUI.skin.label.fontSize = 50;

    //     GUILayout.Label($"time: {t}");
    //     GUILayout.Label($"bpm: {BPM}");

    // }
}
