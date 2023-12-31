import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { LayoutComponent } from './layout.component';
import { DashBoardComponent } from './Pages/dash-board/dash-board.component';
import { HistorialVentaComponent } from './Pages/historial-venta/historial-venta.component';
import { ProductoComponent } from './Pages/producto/producto.component';
import { ReporteComponent } from './Pages/reporte/reporte.component';
import { VentaComponent } from './Pages/venta/venta.component';
import { ClienteComponent } from './Pages/cliente/cliente.component';
import { EmpleadoComponent } from './Pages/empleado/empleado.component';



const routes: Routes = [{
  path:'',
  component:LayoutComponent,
  children: [
    {path:'dashboard',component:DashBoardComponent},
    {path:'clientes',component:ClienteComponent},
    {path:'empleados',component:EmpleadoComponent},
    {path:'productos',component:ProductoComponent},
    {path:'venta',component:VentaComponent},
    {path:'historial_venta',component:HistorialVentaComponent},
    {path:'reportes',component:ReporteComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
