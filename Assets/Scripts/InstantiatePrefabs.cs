using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour {
    public GameObject[] cameraPrefabs;
    private int _index;
    private GameObject _currentCamera;

    private void Start() {
        _currentCamera = Instantiate(cameraPrefabs[0]);
    }

    public void NextSkybox() {
        Destroy(_currentCamera);
        if (_index < cameraPrefabs.Length -1) 
            _index++;
        else 
            _index = 0;

        _currentCamera = Instantiate(cameraPrefabs[_index]);
    }
}
