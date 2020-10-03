using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        UserResponseModel UserRegistration(RegisterationModel registerationModel);

        UserResponseModel UserLogin(LoginModel loginModel);
    }
}
