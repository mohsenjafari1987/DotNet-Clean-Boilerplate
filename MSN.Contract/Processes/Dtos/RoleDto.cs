namespace MSN.Contract.Processes.Dtos
{
    public record RoleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
    }
}
