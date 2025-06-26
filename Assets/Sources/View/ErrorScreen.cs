using System;
using UnityEngine;
using UnityEngine.UI;

public class ErrorScreen : MonoBehaviour
{
    [SerializeField] private Button _gotIt;

    public event Action OnGotItClicked;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    private void Start()
    {
        _gotIt.onClick.AddListener(delegate { OnGotItClicked?.Invoke(); });
    }
}