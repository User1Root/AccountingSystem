# AccountingSystem
Как настроить базу данных из скрипта (VisualStudio 2019):
1)Обозреватель серверов -> Подключение данных ->
Добавить подключение :
     Источник данных:
     Файл базы данных Microsoft SQL Server (SqlClient)
     Имя файла базы данных:
     ESMDB
2)новый запрос к базе -> копируем создержимое scriptesm.sql и запускаем
3) (ESMWeb) в файл appsetting.json, в ConnectionString, в атрибут EsmDB добавить строку подключения новой БД.
     
