namespace UltraNuke.Barasingha.Todoing.API.Application.IntegrationEvents.Events
{
    using System;

    public class TodoUpdatedIntegrationEvent
    {
        public Guid TodoId { get; }
        public string Name { get; }

        public TodoUpdatedIntegrationEvent(Guid todoId,string name)
        {
            this.TodoId = todoId;
            this.Name = name;
        }
    }
}