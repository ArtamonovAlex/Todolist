using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TodoListLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ITodoEditor" в коде и файле конфигурации.
    [ServiceContract]
    public interface ITodoEditor
    {
        [OperationContract]
        string GetList();

        [OperationContract]
        string GetTask(Task task);

        [OperationContract]
        void InitializeList(string username);

        [OperationContract]
        void AddTask(Task task);
    }
}
