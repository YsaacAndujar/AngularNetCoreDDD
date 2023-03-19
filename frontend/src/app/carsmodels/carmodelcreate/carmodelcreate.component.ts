import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import { CrudapiService } from 'src/app/crudapi.service';
import { CarModel } from 'src/app/interfaces/carmodel';
import { Brand } from 'src/app/interfaces/brand';

@Component({
  selector: 'app-carmodelcreate',
  templateUrl: './carmodelcreate.component.html',
  styleUrls: ['./carmodelcreate.component.css']
})
export class CarmodelcreateComponent {
  creating:Boolean = false
  brands:Brand[] = []
  ngOnInit():void{
    this.api.setBase('brands')
    this.api.getAll().subscribe((data: Brand[]) => {
      this.brands = data
    });
  }
  constructor(private api: CrudapiService<CarModel, number>){
  }
  get name(){
    return this.formCarModel.get('name')
  }
  get brandId(){
    return this.formCarModel.get('brandId')
  }
  formCarModel = new FormGroup({
    'name': new FormControl('', Validators.required),
    'brandId': new FormControl(0, Validators.required),
  })
  submit(){
    this.creating = true
    this.api.setBase('carmodels')
    this.api.create(this.formCarModel.value as CarModel).subscribe((data: CarModel) => {
      alert(`CarModel: ${data.name} created with Id: ${data.id}`)
      this.formCarModel.reset()
      this.creating = false
    });
  }
}
