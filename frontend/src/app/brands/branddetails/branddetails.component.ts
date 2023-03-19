import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Brand } from 'src/app/interfaces/brand';
import { CrudapiService } from 'src/app/crudapi.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-branddetails',
  templateUrl: './branddetails.component.html',
  styleUrls: ['./branddetails.component.css']
})
export class BranddetailsComponent {
  loading:Boolean = false
  constructor(private api: CrudapiService<Brand, number>,private route: ActivatedRoute){
    api.setBase('brands')
  }
  get name(){
    return this.formBrand.get('name')
  }
  formBrand = new FormGroup({
    'id': new FormControl(0,Validators.required),
    'name': new FormControl('', Validators.required)
  })
  ngOnInit():void{
    this.loading = true
    const id = this.route.snapshot.params['id'];
    this.api.findById(id).subscribe((data:Brand) => {
      this.formBrand.patchValue(data)
      this.loading = false
    },(error:any)=>{
      console.log(error)
      alert(`Error fetching brands: ${error}`)
    });
  }
  submit(){
    this.api.update(this.formBrand.value as Brand).subscribe((data: Brand) => {
      alert('Brand: updated')
    });
  }
}
