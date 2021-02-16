using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourcesLoadUnload : MonoBehaviour {
    private int _index;
    private Object _currentCamera;

    private void Start() {
        _currentCamera = Instantiate(Resources.Load("Skybox_" + _index));
    }

    public void NextSkybox() {
        Destroy(_currentCamera);
        Resources.UnloadUnusedAssets();
        GC.Collect();
        
        if (_index < 5) 
            _index++;
        else 
            _index = 0;

        _currentCamera = Instantiate(Resources.Load("Skybox_" + _index));
    }
}
