using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Todos.Search
{
    public sealed class TodoSummaryData
    {
        public string Id { get; }
        public string Title { get; }
        public DateTime CreatedDatetime { get; }
        public DateTime UpdatedDateTime { get; }
        public string StatusString { get; }

        public TodoSummaryData(
            string id,
            string title,
            DateTime createdDatetime,
            DateTime updatedDateTime,
            string statusString)
        {
            Id = id;
            Title = title;
            CreatedDatetime = createdDatetime;
            UpdatedDateTime = updatedDateTime;
            StatusString = statusString;
        }
    }
}
