namespace crudApi.C_Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive => true;
    }
}