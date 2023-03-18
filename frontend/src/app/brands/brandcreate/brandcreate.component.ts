import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Brand } from 'src/app/brand';
import { CrudapiService } from 'src/app/crudapi.service';

@Component({
  selector: 'app-brandcreate',
  templateUrl: './brandcreate.component.html',
  styleUrls: ['./brandcreate.component.css']
})
export class BrandcreateComponent {
  creating:Boolean = false
  constructor(private api: CrudapiService<Brand, number>){
    api.setBase('brands')
  }
  get name(){
    return this.formBrand.get('name')
  }
  formBrand = new FormGroup({
    'name': new FormControl('', Validators.required)
  })
  submit(){
    this.creating = true
    this.api.create(this.formBrand.value as Brand).subscribe((data: Brand) => {
      alert(`Brand: ${data.name} created with Id: ${data.id}`)
      this.formBrand.reset()
      this.creating = false
    });
  }
}
