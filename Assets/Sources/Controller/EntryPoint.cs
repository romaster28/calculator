using System.IO;
using Sources.Model;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private MainScreen _mainScreen;

    [SerializeField] private ErrorScreen _errorScreen;

    [SerializeField] private OperationsShower _operationsShower;

    [SerializeField] private CurrentInputSaver _currentInputSaver;

    private Calculator _calculator;

    private OperationsHistory _history;

    private void MainScreenOnOnResultClickTried(string input)
    {
        var result = _calculator.Execute(input);

        _history.WriteNewOperation(result);

        if (!result.Success)
            _errorScreen.Show();
    }

    private void Awake()
    {
        _calculator = new Calculator(new IOperation[]
        {
            new SumTwoIntegersOperation()
        });

        _history = new OperationsHistory(Path.Combine(Application.persistentDataPath, "history.json"));
    }

    private void OnEnable()
    {
        _errorScreen.Hide();
        
        _operationsShower.ClearAll();
        
        _mainScreen.OnResultClickTried += MainScreenOnOnResultClickTried;

        _errorScreen.OnGotItClicked += _errorScreen.Hide;
        
        _history.NewOperationWritten += _operationsShower.Show;
    }

    private void Start()
    {
        _history.Load();

        foreach (var loadedOperation in _history.Operations) 
            _operationsShower.Show(loadedOperation);
        
        _currentInputSaver.Load();
    }

    private void OnDisable()
    {
        _mainScreen.OnResultClickTried -= MainScreenOnOnResultClickTried;
        
        _errorScreen.OnGotItClicked -= _errorScreen.Hide;
        
        _history.NewOperationWritten -= _operationsShower.Show;
        
        _history.Save();
        
        _currentInputSaver.Save();
    }
}