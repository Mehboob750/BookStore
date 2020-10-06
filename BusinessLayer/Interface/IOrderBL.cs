using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.ResponseModel;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        OrderResponseModel BookOrder(int claimId, int CartId);

        List<OrderResponseModel> GetAllOrderValues();
    }
}
