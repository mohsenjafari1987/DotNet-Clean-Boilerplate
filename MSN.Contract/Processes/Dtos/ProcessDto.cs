namespace MSN.Contract.Processes.Dtos
{
    public record ProcessDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime Created { get; set; }
    }
    public record ProcessDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public List<DepartmentDto>? departments { get; set; }
        public List<LocationDto>? Locations { get; set; }
        public List<ResourceDto>? Resources { get; set; }
        public List<RoleDto>? Roles { get; set; } 
        public UserDto CreatedBy { get; set; } = default!;
    }
}
