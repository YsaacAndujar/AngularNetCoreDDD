import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CrudapiService } from 'src/app/crudapi.service';
import { Brand } from 'src/app/interfaces/brand';
import { Car } from 'src/app/interfaces/car';
import { CarModel } from 'src/app/interfaces/carmodel';

@Component({
  selector: 'app-cardetails',
  templateUrl: './cardetails.component.html',
  styleUrls: ['./cardetails.component.css']
})
export class CardetailsComponent {
  loading:Boolean = false
  brands:Brand[] = []
  brandId: number = 0
  carModels:CarModel[] = []
  constructor(private api: CrudapiService<Car, number>,private route: ActivatedRoute, private apiBrandModel: CrudapiService<CarModel, number>, private router: Router){
    api.setBase('brands')
  }
  get year(){
    return this.formCar.get('year')
  }
  get carModelId(){
    return this.formCar.get('carModelId')
  }
  get carModelsFiltered(){
    return this.carModels.filter(cm => cm.brandId == this.brandId)
  }
  formCar = new FormGroup({
    'id': new FormControl(0,Validators.required),
    'year': new FormControl(0, Validators.required),
    'carModelId': new FormControl(0, Validators.required),
  })
  ngOnInit():void{
    this.loading = true
    this.apiBrandModel.setBase('brands')
    this.apiBrandModel.getAll().subscribe((data: Brand[]) => {
      this.brands = data
    });
    this.apiBrandModel.setBase('carmodels')
    this.apiBrandModel.getAll().subscribe((data: CarModel[]) => {
      this.carModels = data
    });
    this.api.setBase('cars')

    const id = this.route.snapshot.params['id'];
    this.api.findById(id).subscribe((data:Car) => {
      this.brandId = data.carModel.brandId
      this.formCar.patchValue(data)
      this.loading = false
    },(error:any)=>{
      console.log(error)
      alert(`Error fetching car`)
    });
  }
  submit(){
    this.api.setBase('cars')
    this.api.update(this.formCar.value as Car).subscribe((data: Car) => {
      alert('Car: updated')
    });
  }
  deleteEntity(){
    if (!confirm('Are you sure that you want to delete this entity and the data related?')) {
      return
    }
    const id = this.route.snapshot.params['id'];
    this.api.delete(id).subscribe(()=>{
      this.router.navigate(['/cars']);
    })
  }
}
