namespace MSN.Framework.BaseModel
{
    public class BaseModel
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; } = default!;
        public DateTime Created { get; protected set; }
    }
}