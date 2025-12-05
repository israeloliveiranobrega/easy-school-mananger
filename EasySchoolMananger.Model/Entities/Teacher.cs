using EasySchoolMananger.Model.Base;
using System.Numerics;

namespace EasySchoolMananger.Model.Entities;

public class Teacher : BaseMetaData
{
    public int Customer_Id { get; set; }
    public DateOnly AdmissionDate { get; set; }
}
