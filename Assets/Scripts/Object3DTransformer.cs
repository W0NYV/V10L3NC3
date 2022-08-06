using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class Object3DTransformer : MonoBehaviour {
    
    public Action action;

    // Start is called before the first frame update
    void Start() {

        action();

    }

    public void TranslateUp() {
        transform.DOMoveY(1.0f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(this.gameObject);
        });
    }

    public void TranslateDown() {
        transform.DOMoveY(-1.0f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(this.gameObject);
        });
    }

    public void TranslateRight() {
        transform.DOMoveX(1.66666f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(this.gameObject);
        });
    }

    public void TranslateLeft() {
        transform.DOMoveX(-1.66666f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(this.gameObject);
        });
    }

    public void ShakePosition() {
        transform.DOShakePosition(duration: 60.0f/BPMSyncer.BPM, strength: BPMSyncer.BPM/60.0f).OnComplete(() => {
            Destroy(this.gameObject);
        });
    }


}
