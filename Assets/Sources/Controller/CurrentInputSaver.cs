using UnityEngine;

public class CurrentInputSaver : MonoBehaviour
{
    [SerializeField] private MainScreen _mainScreen;
    
    private const string Key = "Current";
    
    public void Save()
    {
        PlayerPrefs.SetString(Key, _mainScreen.CurrentInput);
    }

    public void Load()
    {
        _mainScreen.SetCurrentInput(PlayerPrefs.GetString(Key));
    }
}