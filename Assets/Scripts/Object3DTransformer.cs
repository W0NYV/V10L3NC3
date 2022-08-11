using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class Object3DTransformer : MonoBehaviour {
    
    static public void Translate0(GameObject obj) {
        obj.transform.DOMove(Vector3.zero, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(obj);
        });
    }

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

    static public void TranslateZ(GameObject obj) {
        obj.transform.DOMoveZ(5.0f, 60.0f/BPMSyncer.BPM).OnComplete(() => {
            Destroy(obj);
        });
    }

    static public void ShakePosition(GameObject obj) {
        obj.transform.DOShakePosition(duration: 60.0f/BPMSyncer.BPM, strength: BPMSyncer.BPM/60.0f).OnComplete(() => {
            Destroy(obj);
        });
    }

    static public void ShakeCamera(GameObject obj) {
        obj.transform.DOShakePosition(duration: 60.0f/BPMSyncer.BPM, strength: 2.0f).OnComplete(() => {
            obj.transform.DOMove(new Vector3(0, 0, 3.0f), 0.05f);
        });
    }

    static public void ScaleRotate4(GameObject obj) {

        float duration = 60.0f / BPMSyncer.BPM / 2.0f;
        Vector3 angle = new Vector3(180, 180, 0);
        Vector3 scale = new Vector3(0.7f, -0.7f, 0.7f);

        obj.transform.DOScale(scale, duration);
        obj.transform.DORotate(angle, duration).OnComplete(() => {
           
            GameObject o = Instantiate(obj, new Vector3(0.5f, 0, 0), Quaternion.identity);

            o.transform.DOScale(scale, duration);
            o.transform.DORotate(angle, duration).OnComplete(() => {

                GameObject o2 = Instantiate(o, new Vector3(-0.5f, 0, 0), Quaternion.identity);

                o2.transform.DOScale(scale, duration);
                o2.transform.DORotate(angle, duration).OnComplete(() => {

                    GameObject o3 = Instantiate(o2, new Vector3(-1.5f, 0, 0), Quaternion.identity);

                    o3.transform.DOScale(scale, duration);
                    o3.transform.DORotate(angle, duration).OnComplete(() => {
          
                        Destroy(obj);
                        Destroy(o);
                        Destroy(o2);
                        Destroy(o3);

                    });  
                });
            });
        });
    }

    static public void ScaleRotate42(GameObject obj) {

        float duration = 60.0f / BPMSyncer.BPM;
        Vector3 angle = new Vector3(0, 0, 180);
        Vector3 scale = Vector3.zero;

        obj.transform.DOScale(scale, duration);
        obj.transform.DORotate(angle, duration).OnComplete(() => {
           
            GameObject o = Instantiate(obj, new Vector3(1.5f, -1.0f, 0), Quaternion.identity);
            o.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            o.transform.DOScale(scale, duration);
            o.transform.DORotate(angle, duration).OnComplete(() => {

                GameObject o2 = Instantiate(o, new Vector3(-1.5f, 1.0f, 0), Quaternion.identity);
                o2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                o2.transform.DOScale(scale, duration);
                o2.transform.DORotate(angle, duration).OnComplete(() => {

                    GameObject o3 = Instantiate(o2, new Vector3(-1.5f, -1.0f, 0), Quaternion.identity);
                    o3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                    o3.transform.DOScale(scale, duration);
                    o3.transform.DORotate(angle, duration).OnComplete(() => {
          
                        Destroy(obj);
                        Destroy(o);
                        Destroy(o2);
                        Destroy(o3);

                    });  
                });
            });
        });
    }

    static public void RotateY(GameObject obj) {
        obj.transform.DORotate(new Vector3(0, 360.0f, 0), 60.0f/BPMSyncer.BPM, RotateMode.FastBeyond360).OnComplete(() => {
            Destroy(obj);
        });
    }

    static public void ShakeSize(GameObject obj) {
        obj.transform.DOShakeScale(60.0f/BPMSyncer.BPM, 1.5f).OnComplete(() => {
            Destroy(obj);
        });
    }

}
