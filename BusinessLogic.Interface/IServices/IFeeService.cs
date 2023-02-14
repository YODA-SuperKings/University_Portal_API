using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface IFeeService
    {
        List<Fee> GetFee();
        string CreateFee(Fee _Fee);
    }
}
