using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;
using CommanLayer.RequestModel;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        UserModel UserRegistration(RegisterationModel registerationModel);
        
        UserModel UserLogin(LoginModel loginModel);
    }
}
