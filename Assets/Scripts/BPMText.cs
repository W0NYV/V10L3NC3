using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BPMText : MonoBehaviour {

    TextMeshProUGUI _text;

    private void Awake() {
        TryGetComponent(out _text);
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
        float fps = 1f / Time.deltaTime;

        _text.text = "FPS:" + fps.ToString("0.00") + "\n" + "BPM:" + BPMSyncer.BPM.ToString("0.00");
        
    }
}
