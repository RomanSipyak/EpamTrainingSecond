# :orange_book: HomeworkTasks :orange_book:
**Task 1**

    Створити рекурсивний метод. Добитись генерації StackOverflowException.

**Task 2**

    Створити метод в якому використовуючи одновимірний масив добитись генерації IndexOutOfRangeException.
    
**Task 3** 

    Переконатись що згенеровані вийнятки залогувались в програмі Event Viewer.
    
**Task4**

    Огорнути створені в завданнях 1 та 2 методи в конструкцію try-catch-catch.
    Вивести на консоль поле e.Message для кожного з згенерованих вийнятків.

**Task5**

     Створити метод void DoSomeMath(int a, int b), який буде генерувати вийнятки:
     ArgumentException("Parameter should be greater than 0", "a"), якщо а < 0
     ArgumentException("Parameter should be less than 0", "b"), якщо b > 0.
     Обробити згенеровані вийнятки за допомогою фільтрації по параметру. Вивести на консоль поле e.Message для кожного з
     згенерованих вийнятків. Переконитись що обидва обробники спрацьовують і виводять відповідне повідомлення на
     консоль.