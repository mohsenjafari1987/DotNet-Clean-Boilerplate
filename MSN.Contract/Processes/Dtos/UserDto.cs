namespace MSN.Contract.Processes.Dtos
{
    public record UserDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
    }
}
