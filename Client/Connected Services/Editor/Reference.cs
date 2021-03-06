﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Editor {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Editor.ITodoEditor")]
    public interface ITodoEditor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/GetList", ReplyAction="http://tempuri.org/ITodoEditor/GetListResponse")]
        string GetList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/GetList", ReplyAction="http://tempuri.org/ITodoEditor/GetListResponse")]
        System.Threading.Tasks.Task<string> GetListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/GetTask", ReplyAction="http://tempuri.org/ITodoEditor/GetTaskResponse")]
        string GetTask(TodoListLib.Task task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/GetTask", ReplyAction="http://tempuri.org/ITodoEditor/GetTaskResponse")]
        System.Threading.Tasks.Task<string> GetTaskAsync(TodoListLib.Task task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/InitializeList", ReplyAction="http://tempuri.org/ITodoEditor/InitializeListResponse")]
        bool InitializeList(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/InitializeList", ReplyAction="http://tempuri.org/ITodoEditor/InitializeListResponse")]
        System.Threading.Tasks.Task<bool> InitializeListAsync(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/AddTask", ReplyAction="http://tempuri.org/ITodoEditor/AddTaskResponse")]
        void AddTask(string task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/AddTask", ReplyAction="http://tempuri.org/ITodoEditor/AddTaskResponse")]
        System.Threading.Tasks.Task AddTaskAsync(string task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/FindTasks", ReplyAction="http://tempuri.org/ITodoEditor/FindTasksResponse")]
        string FindTasks(string[] tags);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/FindTasks", ReplyAction="http://tempuri.org/ITodoEditor/FindTasksResponse")]
        System.Threading.Tasks.Task<string> FindTasksAsync(string[] tags);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/DeleteTasks", ReplyAction="http://tempuri.org/ITodoEditor/DeleteTasksResponse")]
        void DeleteTasks(string tasks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/DeleteTasks", ReplyAction="http://tempuri.org/ITodoEditor/DeleteTasksResponse")]
        System.Threading.Tasks.Task DeleteTasksAsync(string tasks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/Save", ReplyAction="http://tempuri.org/ITodoEditor/SaveResponse")]
        bool Save(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/Save", ReplyAction="http://tempuri.org/ITodoEditor/SaveResponse")]
        System.Threading.Tasks.Task<bool> SaveAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/Load", ReplyAction="http://tempuri.org/ITodoEditor/LoadResponse")]
        bool Load(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/Load", ReplyAction="http://tempuri.org/ITodoEditor/LoadResponse")]
        System.Threading.Tasks.Task<bool> LoadAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/SaveMain", ReplyAction="http://tempuri.org/ITodoEditor/SaveMainResponse")]
        bool SaveMain(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITodoEditor/SaveMain", ReplyAction="http://tempuri.org/ITodoEditor/SaveMainResponse")]
        System.Threading.Tasks.Task<bool> SaveMainAsync(string tableName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITodoEditorChannel : Client.Editor.ITodoEditor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TodoEditorClient : System.ServiceModel.ClientBase<Client.Editor.ITodoEditor>, Client.Editor.ITodoEditor {
        
        public TodoEditorClient() {
        }
        
        public TodoEditorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TodoEditorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TodoEditorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TodoEditorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetList() {
            return base.Channel.GetList();
        }
        
        public System.Threading.Tasks.Task<string> GetListAsync() {
            return base.Channel.GetListAsync();
        }
        
        public string GetTask(TodoListLib.Task task) {
            return base.Channel.GetTask(task);
        }
        
        public System.Threading.Tasks.Task<string> GetTaskAsync(TodoListLib.Task task) {
            return base.Channel.GetTaskAsync(task);
        }
        
        public bool InitializeList(string tableName) {
            return base.Channel.InitializeList(tableName);
        }
        
        public System.Threading.Tasks.Task<bool> InitializeListAsync(string tableName) {
            return base.Channel.InitializeListAsync(tableName);
        }
        
        public void AddTask(string task) {
            base.Channel.AddTask(task);
        }
        
        public System.Threading.Tasks.Task AddTaskAsync(string task) {
            return base.Channel.AddTaskAsync(task);
        }
        
        public string FindTasks(string[] tags) {
            return base.Channel.FindTasks(tags);
        }
        
        public System.Threading.Tasks.Task<string> FindTasksAsync(string[] tags) {
            return base.Channel.FindTasksAsync(tags);
        }
        
        public void DeleteTasks(string tasks) {
            base.Channel.DeleteTasks(tasks);
        }
        
        public System.Threading.Tasks.Task DeleteTasksAsync(string tasks) {
            return base.Channel.DeleteTasksAsync(tasks);
        }
        
        public bool Save(string path) {
            return base.Channel.Save(path);
        }
        
        public System.Threading.Tasks.Task<bool> SaveAsync(string path) {
            return base.Channel.SaveAsync(path);
        }
        
        public bool Load(string path) {
            return base.Channel.Load(path);
        }
        
        public System.Threading.Tasks.Task<bool> LoadAsync(string path) {
            return base.Channel.LoadAsync(path);
        }
        
        public bool SaveMain(string tableName) {
            return base.Channel.SaveMain(tableName);
        }
        
        public System.Threading.Tasks.Task<bool> SaveMainAsync(string tableName) {
            return base.Channel.SaveMainAsync(tableName);
        }
    }
}
