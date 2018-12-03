using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_ConSQL.Classes
{
    public class Cliente
    {
        public int ID;
        public string Nombre, APaterno, AMaterno, Correo, RFC, Domicilio, Telefono, Path;

        public Cliente()
        {

        }

        public Cliente(string Nombre, string APaterno, string AMaterno, string Correo, string RFC, string Domicilio, string Telefono, string Path)
        {
            this.ID = 0;
            this.Nombre = Nombre;
            this.APaterno = APaterno;
            this.AMaterno = AMaterno;
            this.Correo = Correo;
            this.RFC = RFC;
            this.Domicilio = Domicilio;
            this.Telefono = Telefono;
            this.Path = Path;
        }

        public Cliente(int ID, string Nombre, string APaterno, string AMaterno, string Correo, string RFC, string Domicilio, string Telefono, string Path)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.APaterno = APaterno;
            this.AMaterno = AMaterno;
            this.Correo = Correo;
            this.RFC = RFC;
            this.Domicilio = Domicilio;
            this.Telefono = Telefono;
            this.Path = Path;
        }

        public Cliente(int ID, string Nombre, string APaterno, string AMaterno, string Correo, string RFC, string Domicilio, string Telefono)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.APaterno = APaterno;
            this.AMaterno = AMaterno;
            this.Correo = Correo;
            this.RFC = RFC;
            this.Domicilio = Domicilio;
            this.Telefono = Telefono;
            this.Path = string.Empty;
        }

        public Cliente(string Nombre, string APaterno, string AMaterno, string Correo, string RFC, string Domicilio, string Telefono)
        {
            this.ID = 0;
            this.Nombre = Nombre;
            this.APaterno = APaterno;
            this.AMaterno = AMaterno;
            this.Correo = Correo;
            this.RFC = RFC;
            this.Domicilio = Domicilio;
            this.Telefono = Telefono;
            this.Path = string.Empty;
        }


    }
}
