﻿using System.Collections.Generic;
using System.Linq;
using AllReady.Models;
using AllReady.ViewModels.Event;
using MediatR;

namespace AllReady.Features.Event
{
    public class GetMyTasksQueryHandler : IRequestHandler<GetMyTasksQuery, IEnumerable<TaskSignupViewModel>>
    {
        private readonly IAllReadyDataAccess _allReadyDataAccess;

        public GetMyTasksQueryHandler(IAllReadyDataAccess allReadyDataAccess)
        {
            _allReadyDataAccess = allReadyDataAccess;
        }

        public IEnumerable<TaskSignupViewModel> Handle(GetMyTasksQuery message)
        {
            var tasks = _allReadyDataAccess.GetTasksAssignedToUser(message.EventId, message.UserId);
            return tasks.Select(t => new TaskSignupViewModel(t));
        }
    }
}
