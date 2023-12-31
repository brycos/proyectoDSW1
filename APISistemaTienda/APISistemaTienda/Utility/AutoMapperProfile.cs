﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using APISistemaTienda.Dtos;
using APISistemaTienda.Models;

namespace APISistemaTienda.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion  Menu

            #region Cliente

            CreateMap<Cliente, ClienteDTO>()
                .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0)
                );

            CreateMap<ClienteDTO, Cliente>()
                  .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(origen => origen.Estado == 1 ? true : false)
                );
            #endregion  Cliente

            #region Empleado

            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0)
                );

            CreateMap<EmpleadoDTO, Empleado>()
                  .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(origen => origen.Estado == 1 ? true : false)
                );
            #endregion  Empleado

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            #endregion  Categoria

            #region Producto
            CreateMap<Producto, ProductoDTO>()
                .ForMember(destino =>
                    destino.DescripcionCategoria,
                    opt => opt.MapFrom(origen => origen.IdCatNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Estado,
                    opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0)
                );

            CreateMap<ProductoDTO, Producto>()
               .ForMember(destino =>
                   destino.IdCatNavigation,
                   opt => opt.Ignore()
               )
               .ForMember(destino =>
                   destino.Precio,
                   opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-PE")))
               )
               .ForMember(destino =>
                   destino.Estado,
                   opt => opt.MapFrom(origen => origen.Estado == 1 ? true : false)
               );

            #endregion  Producto

            #region Venta
            CreateMap<Venta, VentaDTO>()
                 .ForMember(destino =>
                    destino.TotalTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                )
                 .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<VentaDTO, Venta>()
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
                );
            #endregion  Venta

            #region DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>()
                .ForMember(destino =>
                    destino.DescripcionProducto,
                    opt => opt.MapFrom(origen => origen.IdProdNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.PrecioTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                 .ForMember(destino =>
                    destino.TotalTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );


            CreateMap<DetalleVentaDTO, DetalleVenta>()
                 .ForMember(destino =>
                   destino.Precio,
                   opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-PE")))
               ).ForMember(destino =>
                   destino.Total,
                   opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
               );

            #endregion  Categoria

            #region Reporte
            CreateMap<DetalleVenta, ReporteDTO>()
                 .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                )
                 .ForMember(destino =>
                    destino.NumeroDocumento,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.NumeroDocumento)
                )
                 .ForMember(destino =>
                    destino.Pago,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.Pago)
                )
                 .ForMember(destino =>
                    destino.TotalVenta,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.Total.Value, new CultureInfo("es-PE")))
                )
                 .ForMember(destino =>
                    destino.Producto,
                    opt => opt.MapFrom(origen => origen.IdProdNavigation.Nombre)
                ).ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );
            #endregion  Reporte


        }
    }
}
