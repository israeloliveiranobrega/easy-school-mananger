using EasySchoolMananger.Model.Base;

namespace EasySchoolMananger.Model.Entities;

public class Secretary : BaseMetaData
{
    public int Customer_Id { get; set; }
    public DateOnly AdmissionDate { get; set; }
}
