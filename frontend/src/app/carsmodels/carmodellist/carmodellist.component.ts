import { Component } from '@angular/core';
import { CrudapiService } from 'src/app/crudapi.service';
import { CarModel } from 'src/app/interfaces/carmodel';

@Component({
  selector: 'app-carmodellist',
  templateUrl: './carmodellist.component.html',
  styleUrls: ['./carmodellist.component.css']
})
export class CarmodellistComponent {
  carModels:CarModel[] = []
  loading: Boolean = true
  constructor(private api: CrudapiService<CarModel, number>){
    api.setBase('carmodels')
  }
  ngOnInit():void{
    this.loading = true
    this.api.getAll().subscribe((data: CarModel[]) => {
      this.carModels = data
      this.loading = false
    });
  }
}
