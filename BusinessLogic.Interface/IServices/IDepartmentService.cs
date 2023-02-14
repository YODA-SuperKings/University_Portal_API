using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface IDepartmentService
    {
        List<Department> GetDepartment();
        string CreateDepartment(Department _Department);
    }
}
