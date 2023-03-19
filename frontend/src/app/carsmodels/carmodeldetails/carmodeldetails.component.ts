import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CrudapiService } from 'src/app/crudapi.service';
import { Brand } from 'src/app/interfaces/brand';
import { CarModel } from 'src/app/interfaces/carmodel';

@Component({
  selector: 'app-carmodeldetails',
  templateUrl: './carmodeldetails.component.html',
  styleUrls: ['./carmodeldetails.component.css']
})
export class CarmodeldetailsComponent {
  loading:Boolean = false
  brands:Brand[] = []
  constructor(private api: CrudapiService<CarModel, number>,private route: ActivatedRoute, private router: Router){
    api.setBase('brands')
  }
  get name(){
    return this.formCarModel.get('name')
  }
  get brandId(){
    return this.formCarModel.get('brandId')
  }
  formCarModel = new FormGroup({
    'id': new FormControl(0,Validators.required),
    'name': new FormControl('', Validators.required),
    'brandId': new FormControl(0, Validators.required),
  })
  ngOnInit():void{
    this.loading = true
    this.api.setBase('brands')
    this.api.getAll().subscribe((data: Brand[]) => {
      this.brands = data
    },(error:any)=>{
      alert(`Error fetching brands`)
    });

    const id = this.route.snapshot.params['id'];
    this.api.setBase('carmodels')
    this.api.findById(id).subscribe((data:CarModel) => {
      this.formCarModel.patchValue(data)
      this.loading = false
    },(error:any)=>{
      console.log(error)
      alert(`Error fetching car models`)
    });
  }
  submit(){
    this.api.setBase('carmodels')
    this.api.update(this.formCarModel.value as CarModel).subscribe((data: CarModel) => {
      alert('CarModel: updated')
    });
  }
  deleteEntity(){
    if (!confirm('Are you sure that you want to delete this entity and the data related?')) {
      return
    }
    const id = this.route.snapshot.params['id'];
    this.api.delete(id).subscribe(()=>{
      this.router.navigate(['/carsmodels']);
    })
  }
}