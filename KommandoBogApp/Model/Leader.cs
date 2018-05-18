﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommandoBogApp.Model
{
    public class Leader: User
    {

        public Leader(string maNummer, string navn, string tlf, string adresse, string email, string password) : base(maNummer, navn, tlf, adresse, email, password)
        {
            UserType = "Leader";
        }

        public void ApproveWork()
        {

        }
    }
}
