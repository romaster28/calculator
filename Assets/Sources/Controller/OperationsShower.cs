using System;
using System.Text;
using Sources.Model;
using UnityEngine;

public class OperationsShower : MonoBehaviour
{
    [SerializeField] private HistoryView _view;
    
    private readonly StringBuilder _operationViewBuilder = new();
    
    public void Show(ResultOperation resultOperation)
    {
        if (resultOperation == null)
            throw new ArgumentNullException(nameof(resultOperation));
        
        _operationViewBuilder.Clear();

        _operationViewBuilder.Append(resultOperation.Expression);

        _operationViewBuilder.Append('=');

        if (resultOperation.Success)
            _operationViewBuilder.Append(resultOperation.Result);
        else
            _operationViewBuilder.Append("ERROR");
        
        _view.Push(_operationViewBuilder.ToString());
    }

    public void ClearAll()
    {
        _view.Clear();
    }
}