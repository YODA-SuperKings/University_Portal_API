using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface IExaminationsService
    {
        List<Examinations> GetExaminations();
        string CreateExaminations(Examinations _Examinations);
    }
}
