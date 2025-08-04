using MSN.Domain.Models.Locations;
using MSN.Domain.Models.Processes;
using MSN.Domain.Models.Users;
using MSN.Framework.BaseModel;

namespace MSN.Domain.Models.Resources
{
    public class Resource : BaseModel
    {
        public int CreatedById { get; private set; }
        public User CreatedBy { get; private set; } = default!;
        public List<Process> Processes { get; private set; } = default!;

        public static Resource Create(int id, string title, User user)
        {
            var resource = new Resource
            {
                Id = id,
                Title = title,
                CreatedBy = user
            };

            return resource;
        }
    }
}
