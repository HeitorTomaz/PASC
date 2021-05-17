using System;
using System.Collections.Generic;
using PASC.VO;

namespace PASC.DAL
{
    public interface ISql
    {
        User GetUser(string code);
        void NewUser(User user);
        //void SetUserBirth(User user, DateTime birth);
        //void SetUserGender(User user, Gender gender);

    }
}