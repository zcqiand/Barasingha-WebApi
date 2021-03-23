using MediatR;
using UltraNuke.Barasingha.Todoing.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Todoing.Domain.Events
{
    /// <summary>
    /// 已更新待办事项时的事件
    /// </summary>
    public class TodoUpdatedDomainEvent : INotification
    {
        public Todo Todo { get; }

        public TodoUpdatedDomainEvent(Todo todo)
        {
            Todo = todo;
        }
    }
}
