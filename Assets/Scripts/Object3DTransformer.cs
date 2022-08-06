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

        Debug.Log("aaaa");

    }

    public void TranslateDown() {

        Debug.Log("iiii");

    }

    public void ShakePosition() {
        transform.DOShakePosition(duration: 1f, strength: 1.5f).OnComplete(() => {
            Destroy(this.gameObject);
        });
    }


}
