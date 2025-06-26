using UnityEngine;

public class HistoryView : MonoBehaviour
{
    [SerializeField] private OperationView _operationPrefab;

    [SerializeField] private Transform _operationsParent;
    
    public void Clear()
    {
        for (int i = 0; i < _operationsParent.childCount; i++) 
            Destroy(_operationsParent.GetChild(i).gameObject);
    }

    public void Push(string operation)
    {
        var created = Instantiate(_operationPrefab, _operationsParent);
        
        created.UpdateView(operation);
    }
}