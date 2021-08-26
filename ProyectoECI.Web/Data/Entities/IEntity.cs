using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoECI.Web.Data.Entities
{
    //TODAS LAS CLASES VAN A TENER UNA ID 
    public interface IEntity
    {
        int Id { get; set; }
    }
}
