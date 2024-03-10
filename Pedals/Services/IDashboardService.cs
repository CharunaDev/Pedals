using System;
using System.Collections.Generic;

namespace Pedals.Services
{
    public interface IDashboardService
    {
        List <order> GetOrderDetails(DateTime FromDate, DateTime ToDate, string Status, int PageNumber, int PageSize); 
    }
}