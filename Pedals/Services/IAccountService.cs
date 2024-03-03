using Pedals.Models;
using System;
using System.Collections.Generic;
using System.Data;


namespace Pedals.Services
{

    public interface IAccountService
    {
        List<staff> GetStaffDetails(int? staff_id);
    }
}