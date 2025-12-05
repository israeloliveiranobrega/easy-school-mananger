using EasySchoolMananger.Model.Base;

namespace EasySchoolMananger.Model.Entities;

public class Coordinator : BaseMetaData
{
    public int Customer_Id { get; set; }
    public DateOnly AdmissionDate { get; set; }
}
