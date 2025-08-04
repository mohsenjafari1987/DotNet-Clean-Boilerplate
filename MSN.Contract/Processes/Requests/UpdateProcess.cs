namespace MSN.Contract.Processes.Requests
{
    public record UpdateProcessRequest
    {
        public int Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
    }
}
