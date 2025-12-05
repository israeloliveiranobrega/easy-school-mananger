namespace EasySchoolMananger.Model.Base
{
    public abstract class BaseMetaData
    {
        //Identificador Primary Key
        public int Id { get; set; }

        //metadados de criação
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }

        //metadados de atualização
        public string? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        //metadados de exclusão (esconder)
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }

        //versão do registro
        public uint Version { get; set; }
    }
}
