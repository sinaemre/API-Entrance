namespace API_Entrance.Core.Entities.Abstract
{
    public enum Status { Active = 1, Modified, Passive }
    public abstract class BaseEntity
    {
        private DateTime _createdDate = DateTime.Now;
        private Status _status = Status.Active;

        public int Id { get; set; }

        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get => _status; set => _status = value; }
    }
}
