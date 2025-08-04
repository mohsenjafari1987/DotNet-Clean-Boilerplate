using MSN.Domain.Models.Departments;
using MSN.Domain.Models.Locations;
using MSN.Domain.Models.Processes;
using MSN.Domain.Models.Resources;
using MSN.Domain.Models.Roles;
using MSN.Framework.BaseModel;

namespace MSN.Domain.Models.Users
{
    public class User : BaseModel
    {
        public List<Process> Processes { get; private set; } = default!;
        public List<Department> Departments { get; private set; } = default!;
        public List<Role> Roles { get; private set; } = default!;
        public List<Resource> Resources { get; private set; } = default!;
        public List<Location> Locations { get; private set; } = default!;


        public static User Create(int id, string title)
        {
            var user = new User
            { 
                Id = id,
                Title = title,
            };

            return user;
        }
    }
}