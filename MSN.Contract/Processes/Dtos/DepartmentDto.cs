namespace MSN.Contract.Processes.Dtos
{
    public record DepartmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
    }
}
