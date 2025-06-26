using TMPro;
using UnityEngine;

public class OperationView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    
    public void UpdateView(string operation)
    {
        _view.text = operation;
    }
}