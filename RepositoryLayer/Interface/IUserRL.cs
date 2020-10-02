using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;
using CommanLayer.RequestModel;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        UserModel UserRegistration(RegisterationModel registerationModel);
    }
}
