using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

using IncentiveTest.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IncentiveTest.Methods
{
    public static class WebResponse
    {
        public static IList<Cliente> GetAllClients(string requestUrl)
        {
            IList<Cliente> clientes = new List<Cliente>();
            try
            {
                WebRequest request = WebRequest.Create(requestUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return clientes;
                }

                using (StreamReader sr = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType != JsonToken.StartObject) continue;
                        JObject obj = JObject.Load(reader);
                        Cliente cliente = new Cliente
                        {
                            Ciudad = obj["ciudad"].ToString(),
                            Codigo = int.Parse(obj["codigo"].ToString()),
                            Direccion = obj["direccion"].ToString(),
                            Estado = Convert.ToBoolean(obj["estado"]),
                            FechaRegistro = Convert.ToDateTime(obj["fecha_registro"]),
                            Nombre = obj["nombre"].ToString()
                        };
                        clientes.Add(cliente);
                    }
                }
            }
            catch (Exception)
            {
                return clientes;
            }

            return clientes;
        }

        public static Cliente GetCliente(string requestUrl)
        {
            Cliente cliente = new Cliente();
            try
            {
                WebRequest request = WebRequest.Create(requestUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return cliente;
                }

                using (StreamReader sr = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType != JsonToken.StartObject) continue;
                        JObject obj = JObject.Load(reader);
                        cliente.Ciudad = obj["ciudad"].ToString();
                        cliente.Codigo = int.Parse(obj["codigo"].ToString());
                        cliente.Direccion = obj["direccion"].ToString();
                        cliente.Estado = Convert.ToBoolean(obj["estado"]);
                        cliente.FechaRegistro = Convert.ToDateTime(obj["fecha_registro"]);
                        cliente.Nombre = obj["nombre"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                return cliente;
            }

            return cliente;
        }
    }
}