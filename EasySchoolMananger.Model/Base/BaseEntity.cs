
namespace EasySchoolManager.Model.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        //Identificador Primary Key
        public Guid Id { get; set; } = Guid.CreateVersion7();

        //metadados de criação
        public Guid CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }

        //metadados de atualização  
        public Guid? LastUpdatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        //metadados de exclusão (esconder)
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }

        //versão do registro
        public uint Version { get; set; }
    }
}
