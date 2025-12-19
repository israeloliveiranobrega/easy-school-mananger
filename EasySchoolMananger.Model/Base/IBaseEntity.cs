namespace EasySchoolManager.Model.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        //metadados de criação
        Guid CreatedBy { get; set; }
        DateTime CreateDate { get; set; }

        //metadados de atualização  
        Guid? LastUpdatedBy { get; set; }
        DateTime? LastUpdateDate { get; set; }

        //metadados de exclusão (esconder)
        bool IsDeleted { get; set; }
        DateTime? DeletedDate { get; set; }
        Guid? DeletedBy { get; set; }
    }
}
