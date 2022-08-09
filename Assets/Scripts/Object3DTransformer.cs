using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class Object3DTransformer : MonoBehaviour {
    
    static public void TranslateUp(GameObject obj) {
        obj.transform.DOMoveY(1.0f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(obj);
        });
    }

    static public void TranslateDown(GameObject obj) {
        obj.transform.DOMoveY(-1.0f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(obj);
        });
    }

    static public void TranslateRight(GameObject obj) {
        obj.transform.DOMoveX(1.66666f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(obj);
        });
    }

    static public void TranslateLeft(GameObject obj) {
        obj.transform.DOMoveX(-1.66666f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(obj);
        });
    }

    static public void ShakePosition(GameObject obj) {
        obj.transform.DOShakePosition(duration: 60.0f/BPMSyncer.BPM, strength: BPMSyncer.BPM/60.0f).OnComplete(() => {
            Destroy(obj);
        });
    }


}
