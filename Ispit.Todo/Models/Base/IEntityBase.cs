namespace Ispit.Todo.Models.Base
{
    public interface IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
