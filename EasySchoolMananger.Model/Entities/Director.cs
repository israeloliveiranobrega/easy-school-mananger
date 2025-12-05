using EasySchoolMananger.Model.Base;

namespace SchoolMananger.Controllers;

public class Director : BaseMetaData
{
    public int Customer_Id { get; set; }
    public DateOnly AdmissionDate { get; set; }
}
