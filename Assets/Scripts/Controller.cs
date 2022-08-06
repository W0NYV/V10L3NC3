using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Controller : MonoBehaviour {

    public GameObject cube;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
            
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            Debug.Log("aaa");
            Instantiate(cube, Vector3.zero, Quaternion.identity);
        }
        
    }
}
