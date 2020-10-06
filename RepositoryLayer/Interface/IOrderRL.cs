using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        OrderResponseModel BookOrder(int claimId, int CartId);

        List<OrderResponseModel> GetAllOrderValues();
    }
}
