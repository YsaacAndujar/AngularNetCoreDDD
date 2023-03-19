import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CrudapiService } from 'src/app/crudapi.service';
import { Brand } from 'src/app/interfaces/brand';
import { Car } from 'src/app/interfaces/car';
import { CarModel } from 'src/app/interfaces/carmodel';

@Component({
  selector: 'app-carcreate',
  templateUrl: './carcreate.component.html',
  styleUrls: ['./carcreate.component.css']
})
export class CarcreateComponent {
  creating:Boolean = false
  brands:Brand[] = []
  brandId: number = 0
  carModels:CarModel[] = []
  get carModelsFiltered(){
    return this.carModels.filter(cm => cm.brandId == this.brandId)
  }
  ngOnInit():void{
    this.api.setBase('brands')
    this.apiBrandModel.getAll().subscribe((data: Brand[]) => {
      this.brands = data
    });
    this.api.setBase('carmodels')
    this.apiBrandModel.getAll().subscribe((data: CarModel[]) => {
      this.carModels = data
    });
  }
  constructor(private api: CrudapiService<Car, number>, private apiBrandModel: CrudapiService<CarModel, number>){
  }
  get year(){
    return this.formCar.get('year')
  }
  get carModelId(){
    return this.formCar.get('carModelId')
  }
  formCar = new FormGroup({
    'year': new FormControl(1, [Validators.required, Validators.min(0)]),
    'carModelId': new FormControl(0, Validators.required),
  })
  submit(){
    this.creating = true
    this.api.setBase('cars')
    this.api.create(this.formCar.value as Car).subscribe((data: Car) => {
      alert(`Car created with Id: ${data.id}`)
      this.formCar.reset()
      this.brandId = 0
      this.creating = false
    },(error:any)=>{
      alert('Error creating car')
    });
  }
}
