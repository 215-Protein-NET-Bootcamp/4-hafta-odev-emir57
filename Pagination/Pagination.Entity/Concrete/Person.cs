using Core.Entity;

namespace Pagination.Entity.Concrete
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
