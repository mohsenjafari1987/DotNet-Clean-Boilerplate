namespace MSN.Contract.Processes.Dtos
{
    public record ResourceDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
    }
}
