using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;

namespace Business.Implementations
{
    public class ArticuloServices : IArticuloServices
    {
        private readonly GestionPedidosContext _bcontext;

        public ArticuloServices() { }

        public ArticuloServices(GestionPedidosContext bcontext)
        {
            _bcontext = bcontext;
        }

        public List<ArticuloView> ConsultarServicios()

        {
            List<ArticuloView> listaArticuloView = new List<ArticuloView>();
            var listServicios = _bcontext.Articulos.ToList();
            if (listServicios != null)
            {
                foreach (var item in listServicios)
                {
                    ArticuloView ArticuloView = new ArticuloView()
                    {
                        Idarticulo = item.Idarticulo,
                        Descripcion = item.Descripcion,
                        Precio = item.Precio,
                        Stock = item.Stock,

                    };
                    listaArticuloView.Add(ArticuloView);
                }
            }
            return listaArticuloView;
        }

        public ArticuloView Buscar(int id)
        {
            var articuloSearch = _bcontext.Articulos.Find(id);
                if (articuloSearch == null)
            {
                return null;
            }
            var articuloSearchView = new ArticuloView
            {
                Idarticulo = articuloSearch.Idarticulo,
                Descripcion = articuloSearch.Descripcion,
                Precio = articuloSearch.Precio,
                Stock = articuloSearch.Stock,
            };

            return articuloSearchView;
        }

        public Articulo Agregar(int id, string descripcion, decimal precio, int stock)
        {
            // Verificar si el ID ya existe en la base de datos
            var existeArticulo = _bcontext.Articulos.Any(a => a.Idarticulo == id);
            if (existeArticulo)
            {
                throw new Exception("El ID del artículo ya existe en la base de datos.");
            }

            // Validar otros campos si es necesario
            if (string.IsNullOrEmpty(descripcion))
            {
                throw new Exception("La descripción del artículo es obligatoria.");
            }
            // Agregar el nuevo artículo
            var nuevoArticulo = new Articulo
            {
                Idarticulo = id,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock
            };

            _bcontext.Articulos.Add(nuevoArticulo);
            _bcontext.SaveChanges();

            return nuevoArticulo;
        }

        public ArticuloView Actualizar(int id, ArticuloView articulo)
        {
            // Buscar el artículo por su ID
            var articuloExistente = _bcontext.Articulos.Find(id);
            if (articuloExistente == null)
            {
                throw new Exception("El artículo no existe.");
            }

            // Actualizar los datos del artículo con los valores proporcionados
            articuloExistente.Descripcion = articulo.Descripcion;
            articuloExistente.Precio = articulo.Precio;
            articuloExistente.Stock = articulo.Stock;

            // Guardar los cambios en la base de datos
            _bcontext.SaveChanges();

            // Devolver el artículo actualizado
            return new ArticuloView
            {
                Idarticulo = articuloExistente.Idarticulo,
                Descripcion = articuloExistente.Descripcion,
                Precio = articuloExistente.Precio,
                Stock = articuloExistente.Stock
            };
        }

        public int Eliminar(int id)
        {
            var articuloEliminar = _bcontext.Articulos.Find(id);
            _bcontext.Articulos.Remove(articuloEliminar);
            _bcontext.SaveChanges();
            return id;
        }

    }
}
