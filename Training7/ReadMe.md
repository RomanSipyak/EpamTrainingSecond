# :orange_book: HomeworkTasks :orange_book:
## Завдання з фігурами
**Task 1**

    З урахуванням правил StyleCop реалізувати  клас  прямокутників  зі  сторонами,  паралельними  осям  координат.Передбачити 
    можливість  переміщення  прямокутників  на  площині,  зміну  розмірів,  побудову найменшого  прямокутника,  що  містить  два 
    заданих,  а  також  –  прямокутника,  що  є результатом  перетину  двох  прямокутників.

**Task 2**

    Модифікувати попередню задачу, в якій замість прямокутників забезпечити
    пітримку кіл на основі Generics (без перевірки
    паралельності осям координат).
## Завдання з Excel файлами
**Варіант 1.**

**Task**

    Є два списки в Excel файлі, треба знайти всі комірки з унікальними значеннями (які не повторюються) 
    та вивести іх на екран або в файл  в залежності від налаштувань 
    в AppConfig (номера колонок, які порівнювати теж задати в апп конфізі)
  **Варіант 2.**
  
  **Task**

    Є дві папки з файлами (підпапки фраховуємо),  за командою:
           1. вивести список всіх файлів, які дублюються, та іх загальну кількість.
           2. вивести список унікальних файлів по директорії.
           3. вивести результати в файл або на консоль в залежності від налаштувань в AppConfig.

**Загальні вимогои до варіантів**

    Адреси папок задаються в AppConfig.
    Загальна умова. try catch там де потрібно, SOLID, незалежність від інтерфейса (на Dll),
    Сode Style, файли в форматі excel (як для ввода так і виводу) 
    
# :blue_book: Description :blue_book:
**Варіант 1**

    В RunProject у appsetings вказати шляхи для для виводу на консьоль або у файл вказати.
    наприклад:  <add key="TargetForUniqueValues" value="ConsolePrinter"/>
                або
                <add key="TargetForUniqueValues" value="FilePrinter"/>
    В RunProject у appsetings вказати шлях де є списки і колонки для порівняння та файл для виводу результату.
    наприклад: <add key="collumsKays" value="4,5"/>
               <add key="PathToFileWithLists" value="C:\Users\GOOD\Desktop\test.xls"/>
                <add key="TargetFilePath" value="C:\\Users\\GOOD\\Desktop\\FileOut.xls"/>  
                
Вивід у вигляді  

| Unique elements 4  |
| ------------ |
| element1   |
| element2  |
| element3  |


**Варіант 2**

    В RunProject у appsetings вказати шляхи для порівняння папок.
    наприклад: <add key="PathFolderSecond" value="C:\\Users\\GOOD\\Desktop\\web-service 2"/>
                <add key="PathFolderFirst" value="C:\\Users\\GOOD\\Desktop\\web-service"/>
    В RunProject у appsetings вказати шляхи для виводу результатаів у xls файл.
    наприклад: <add key="TargetToOutput" value="C:\Users\GOOD\Desktop\test.xls"/>    
