using System;

namespace CSharpOopLearning;

public class BankAccount
{
    private string _owner;
    private decimal _balance;
    private readonly List<string> _history = new List<string>();
    
    public string Owner { get { return _owner; } }
    public decimal Balance { get { return _balance; } private set { _balance = value; } }
    public IReadOnlyList<string> History { get { return _history; } }
    public bool IsEmpty => _balance == 0; 
    
    public BankAccount(string name)
    {
        _owner = name;
    }
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException();
        _balance += amount;
        _history.Add($"deposit: {amount}");
    }
    
    public void Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > _balance) throw new ArgumentException();
        _balance -= amount;
        _history.Add($"withdraw: -{amount}");
    }
    
    public void PrintHistory()
    {
        foreach (string action in _history) Console.WriteLine(action); 
    }
    
    public void TransferTo(BankAccount target, decimal amount)
    {
        if (amount <= 0 || amount > _balance) throw new ArgumentException();
        Withdraw(amount);
        target.Deposit(amount);
    }
}