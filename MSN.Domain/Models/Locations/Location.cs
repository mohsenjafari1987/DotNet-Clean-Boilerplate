using MSN.Domain.Models.Processes;
using MSN.Domain.Models.Users;
using MSN.Framework.BaseModel;

namespace MSN.Domain.Models.Locations
{
    public class Location : BaseModel
    {
        public int CreatedById { get; private set; }
        public User CreatedBy { get; private set; } = default!;
        public List<Process> Processes { get; private set; } = default!;

        public static Location Create(int id, string title, User user)
        {
            var location = new Location
            {
                Id = id,
                Title = title,
                CreatedBy = user                
            };

            return location;
        }
    }
}
