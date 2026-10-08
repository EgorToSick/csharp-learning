# Изучение ООП в C#
## Свойства (properties) классов
Реализован класс BankAccount со следующими параметрами.
## Переменные
string Owner - имя владельца счёта. Указывается только один раз при создании объекта и доступен для просмотра ({ get; }).\
decimal Balance - баланс текущего счёта. При инициализации равен нулю. Доступен для просмотра и изменяется только внутри класса ({ get; private set; }).\
List<string> History - история счёта (пополнения, снятия). Публичная переменная (public History) доступно только для чтения, а приватная (private _hisroty) - доступна для изменений внутри класса.\
## Методы
Deposit(decimal amount) - пополнение счёта на amount единиц, если amount > 0.\
Withdraw (decimal amount) - снятие amount единиц со счёта, если amount > 0 и amount <= Balance.\
TransferTo(BankAccount target, decimal amount) - перевод amount единиц с текущего счёта на счёт target, если amount > 0 и amount <= Balance.\
PrintHistory() - выводит каждое действие со счётом.
