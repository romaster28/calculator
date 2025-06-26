using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sources.Model;

public class OperationsHistory
{
    private readonly List<ResultOperation> _operations = new();

    private readonly string _saveFilePath;

    public OperationsHistory(string saveFilePath)
    {
        if (string.IsNullOrEmpty(saveFilePath))
            throw new ArgumentException($"Cant be null {nameof(saveFilePath)}");

        if (Path.GetExtension(saveFilePath).ToLower() != ".json")
            throw new ArgumentException("Only json format available");
        
        _saveFilePath = saveFilePath;
    }

    public IEnumerable<ResultOperation> Operations => _operations;
    
    public event Action<ResultOperation> NewOperationWritten;
    
    public void WriteNewOperation(ResultOperation resultOperation)
    {
        if (resultOperation == null)
            throw new ArgumentNullException(nameof(resultOperation));

        if (_operations.Contains(resultOperation))
            throw new InvalidOperationException("This operation has already written");
        
        _operations.Add(resultOperation);
        
        NewOperationWritten?.Invoke(resultOperation);
    }

    public void Save()
    {
        string parsed = JsonConvert.SerializeObject(_operations);
        
        File.WriteAllText(_saveFilePath, parsed);
    }

    public void Load()
    {
        if (!File.Exists(_saveFilePath))
            return;
        
        var loaded = JsonConvert.DeserializeObject<List<ResultOperation>>(File.ReadAllText(_saveFilePath));

        _operations.Clear();
        
        foreach (var operation in loaded) 
            _operations.Add(operation);
    }
}