using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface IProgramsOfferedService
    {
        List<ProgramsOffered> GetProgramsOffered();
        string CreateProgramsOffered(ProgramsOffered _ProgramsOffered);
    }
}
