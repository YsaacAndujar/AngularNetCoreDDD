import { Component } from '@angular/core';
import { Brand } from 'src/app/brand';
import { CrudapiService } from 'src/app/crudapi.service';

@Component({
  selector: 'app-brandlist',
  templateUrl: './brandlist.component.html',
  styleUrls: ['./brandlist.component.css']
})
export class BrandlistComponent {
  brands:Brand[] = []
  loading: Boolean = true
  constructor(private api: CrudapiService<Brand, number>){
    api.setBase('brands')
  }
  ngOnInit():void{
    this.loading = true
    this.api.getAll().subscribe((data: Brand[]) => {
      this.brands = data
      this.loading = false
    });
  }
}
