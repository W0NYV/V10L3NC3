using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjTypeText : MonoBehaviour {

    string[] strArray = {
        "CUBE",
        "QUAD",
        "SPHERE"
    };

    TextMeshProUGUI _text;

    private void Awake() {
        TryGetComponent(out _text);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        _text.text = "OBJ TYPE: " + strArray[Controller.objNum];
    }
}
