﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Services.interfaces
{
    public interface IEmailService
    {
        public void EmailConfirmation(string emailadress, string name);

    }
}
