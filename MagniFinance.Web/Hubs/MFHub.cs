using MagniFinance.Domain.Entities;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MagniFinance.Web.Hubs
{
    [HubName("studentHub")]
    public class StudentHub : Hub
    {
    }

    [HubName("teacherHub")]
    public class TeacherHub : Hub
    {
    }
}