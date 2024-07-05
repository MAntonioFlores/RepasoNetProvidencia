using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        public static (bool, string, Exception) Add(ML.Empresa empresa)
        {
			try
			{
				using (DL.MFloresEmpresaEntities context = new DL.MFloresEmpresaEntities())
				{
					var rowsAffected = context.AddEmpresa(empresa.Nombre, empresa.Logo, empresa.URL, empresa.Direccion);

					if (rowsAffected > 0 )
					{
						return (true, null, null);
					}
					else
					{
						return (false, null, null);
					}

				}
			}
			catch (Exception ex)
			{

				return (false, "Ocurrio un error: " + ex, ex);
			}
        }
		public static (bool, string, Exception) Update(ML.Empresa empresa)
		{
			try
			{
				using (DL.MFloresEmpresaEntities context = new DL.MFloresEmpresaEntities())
				{
					var rowsAffected = context.UpdateEmpresa(empresa.IdEmpresa, empresa.Nombre, empresa.Logo, empresa.URL, empresa.Direccion);

					if(rowsAffected > 0)
					{
						return (true, null, null);
					}
					else
					{
						return(false, null, null);
					}
				}
			}
			catch (Exception ex)
			{
				return(false, "Ocurrio un error: " + ex , ex);
			}
		}

		public static(bool,string, Exception)Delete(int IdEmpresa)
		{
			try
			{
				using (DL.MFloresEmpresaEntities context = new DL.MFloresEmpresaEntities())
				{
					var rowsAffected = context.DeleteEmpresa(IdEmpresa);

					if(rowsAffected > 0)
					{
						return (true, null, null);
					}
					else
					{
						return(false, null, null);
					}
				}
			}
			catch (Exception ex)
			{
                return (false, "Ocurrio un error: " + ex, ex);
            }
		}
		public static(bool,string,ML.Empresa,Exception) GetAll()
		{
			ML.Empresa empresa = new ML.Empresa();
			try
			{
				using (DL.MFloresEmpresaEntities context = new DL.MFloresEmpresaEntities())
				{
					var query = context.GetAllEmpresa().ToList();

					if(query.Count > 0)
					{
						empresa.Empresas = new List<ML.Empresa>();
						foreach (var registro in query)
						{
							ML.Empresa empresaObj = new ML.Empresa();

							empresaObj.IdEmpresa = registro.IdEmpresa;
							empresaObj.Nombre = registro.Nombre;
							empresaObj.Logo = registro.Logo;
							empresaObj.URL = registro.URL;
							empresaObj.Direccion = registro.Dirección;

							empresa.Empresas.Add(empresaObj);
						}
						return (true, null, empresa, null);
					}
					else
					{
						return (false, null,empresa, null);
					}
				}
			}
			catch (Exception ex)
			{
                return (false, "Ocurrio un error: " + ex, null, ex);
            }
		}
		public static(bool,string, Exception)GetById(int? IdEmpresa)
		{
			ML.Empresa empresa = new ML.Empresa();
			try
			{
				using (DL.MFloresEmpresaEntities context = new DL.MFloresEmpresaEntities())
				{
					var query = context.GetByIdEmpresa(IdEmpresa).SingleOrDefault();

					if (query != null)
					{
						empresa.Nombre = query.Nombre;
						empresa.Logo = query.Logo;
						empresa.URL = query.URL;
						empresa.Direccion = query.Dirección;

						return (true, null, null);
					}
					else
					{
						return(false, null, null);
					}

				}
			}
			catch (Exception ex)
			{
                return (false, "Ocurrio un error: " + ex, ex);
            }
		}
    }
}
