namespace MSN.Contract.Processes.Dtos
{
    public record LocationDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
    }
}
