import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BrandsComponent } from './brands/brands.component';
import { CarsmodelsComponent } from './carsmodels/carsmodels.component';
import { CarsComponent } from './cars/cars.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { BranddetailsComponent } from './brands/branddetails/branddetails.component';
import { BrandlistComponent } from './brands/brandlist/brandlist.component';
import { BrandcreateComponent } from './brands/brandcreate/brandcreate.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const appRoutes:Routes=[
  {path:'', component:HomeComponent},
  {path:'brands',component:BrandsComponent,
    children: [
      {path:'',component:BrandlistComponent},
      {path: "create", component:BrandcreateComponent},
      {path: ":id", component:BranddetailsComponent},
    ]
  },
  {path:'carsmodels',component:CarsmodelsComponent},
  {path:'cars',component:CarsComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BrandsComponent,
    CarsmodelsComponent,
    CarsComponent,
    HomeComponent,
    BranddetailsComponent,
    BrandlistComponent,
    BrandcreateComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
