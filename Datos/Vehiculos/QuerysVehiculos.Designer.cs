﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos.Vehiculos {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class QuerysVehiculos {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QuerysVehiculos() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Datos.Vehiculos.QuerysVehiculos", typeof(QuerysVehiculos).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update Vehiculo set 
        ///Chasis =@chasis
        ///      ,Placa =@Placa
        ///      ,Transmision =@Transmision
        ///      ,Combustible =@Combustible
        ///      ,Mantenimiento =@Mantenimiento
        ///      ,Anio =@anio
        ///      ,ModeloID  =@ModeloID
        ///      ,ColorID  =@ColorID
        ///      ,EmpleadoID  =@EmpleadoID
        ///
        ///	  where id= @id.
        /// </summary>
        internal static string AcatualizarVehiculo {
            get {
                return ResourceManager.GetString("AcatualizarVehiculo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update Color set nombre =@nombre where id =@id.
        /// </summary>
        internal static string ActualizarColor {
            get {
                return ResourceManager.GetString("ActualizarColor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update dbo . Marca set nombre= @nombre
        ///  where id =@id.
        /// </summary>
        internal static string ActualizarMarca {
            get {
                return ResourceManager.GetString("ActualizarMarca", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update dbo.Modelo set nombre =@nombre, marcaid=@marcaID
        ///  where id=@id.
        /// </summary>
        internal static string ActualizarModelo {
            get {
                return ResourceManager.GetString("ActualizarModelo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update dbo.color set  borrado =1 where id =@id.
        /// </summary>
        internal static string BorrarColor {
            get {
                return ResourceManager.GetString("BorrarColor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update dbo . Marca set borrado= 1
        ///  where id =@id.
        /// </summary>
        internal static string BorrarMarca {
            get {
                return ResourceManager.GetString("BorrarMarca", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update dbo.Modelo set borrado =1
        ///  where id=@id.
        /// </summary>
        internal static string BorrarModelo {
            get {
                return ResourceManager.GetString("BorrarModelo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update Vehiculo set 
        ///borrado =1
        ///
        ///	  where id= @id.
        /// </summary>
        internal static string BorrarVehiculo {
            get {
                return ResourceManager.GetString("BorrarVehiculo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT  ID
        ///      ,Nombre
        ///  FROM dbo.Color where  borrado =0.
        /// </summary>
        internal static string ConsultaColores {
            get {
                return ResourceManager.GetString("ConsultaColores", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT  ID 
        ///      , Nombre 
        ///  FROM  dbo . Marca where borrado =0.
        /// </summary>
        internal static string ConsultarMarca {
            get {
                return ResourceManager.GetString("ConsultarMarca", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT a.ID
        ///      ,a.Nombre
        ///      ,MarcaID
        ///	  ,b.Nombre as Marca
        ///  FROM dbo.Modelo a
        ///  inner join dbo.marca b on a.marcaid = b.id
        ///    where a.borrado =0.
        /// </summary>
        internal static string ConsultarModelos {
            get {
                return ResourceManager.GetString("ConsultarModelos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///SELECT a.ID
        ///      ,Chasis
        ///      ,Placa
        ///      ,Transmision
        ///      ,Combustible
        ///      ,Mantenimiento
        ///      ,Anio
        ///      ,ModeloID
        ///      ,ColorID
        ///      ,EmpleadoID
        ///	  ,c.Nombre as color
        ///	  ,m.Nombre as modelo
        ///	  ,e.Nombre as empleado
        ///  FROM dbo.Vehiculo a 
        ///  inner join Color c on a.colorid =c.ID
        ///  inner join Modelo m on a.modeloid =m.ID
        ///  inner join Empleado e on a.EmpleadoID =e.ID
        ///  where a.borrado =0 .
        /// </summary>
        internal static string ConsultarVehiculo {
            get {
                return ResourceManager.GetString("ConsultarVehiculo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into Color(nombre, borrado)
        ///  values(@nombre,0).
        /// </summary>
        internal static string InsertarColor {
            get {
                return ResourceManager.GetString("InsertarColor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into dbo . Marca (nombre, borrado) values (@nombre,0).
        /// </summary>
        internal static string InsertarMarca {
            get {
                return ResourceManager.GetString("InsertarMarca", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into dbo.Modelo(nombre,marcaID,borrado)
        ///  values(@nombre,@marcaID,0).
        /// </summary>
        internal static string InsertarModelo {
            get {
                return ResourceManager.GetString("InsertarModelo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into vehiculo(
        ///Chasis
        ///,Placa
        ///,Transmision
        ///,Combustible
        ///,Mantenimiento
        ///,Anio
        ///,ModeloID
        ///,ColorID
        ///,EmpleadoID
        ///,Borrado
        ///)
        ///values 
        ///(
        ///@Chasis
        ///,@Placa
        ///,@Transmision
        ///,@Combustible
        ///,@Mantenimiento
        ///,@Anio
        ///,@ModeloID
        ///,@ColorID
        ///,@EmpleadoID
        ///,0
        ///).
        /// </summary>
        internal static string InsertarVehiculo {
            get {
                return ResourceManager.GetString("InsertarVehiculo", resourceCulture);
            }
        }
    }
}
