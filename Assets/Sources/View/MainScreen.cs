using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private TMP_InputField _equation;

    [SerializeField] private Button _result;

    public event Action<string> OnResultClickTried;

    public string CurrentInput => _equation.text;

    public void SetCurrentInput(string input)
    {
        _equation.text = input;
    }
    
    private void ResultClicked()
    {
        OnResultClickTried?.Invoke(_equation.text);
    }

    private void Start()
    {
        _result.onClick.AddListener(ResultClicked);
    }
}