﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using capa_datos;
//using capa_negocio;

namespace capa_negocio
{
    public class N_Users
    {
        ClsConexion objd = new ClsConexion();

        public DataTable N_user(E_Users obje)
        {
            return objd.D_users(obje);
        }
    }
}
