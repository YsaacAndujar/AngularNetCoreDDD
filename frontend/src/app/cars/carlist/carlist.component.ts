import { Component } from '@angular/core';
import { CrudapiService } from 'src/app/crudapi.service';
import { Car } from 'src/app/interfaces/car';

@Component({
  selector: 'app-carlist',
  templateUrl: './carlist.component.html',
  styleUrls: ['./carlist.component.css']
})
export class CarlistComponent {
  cars:Car[] = []
  loading: Boolean = true
  constructor(private api: CrudapiService<Car, number>){
    api.setBase('cars')
  }
  ngOnInit():void{
    this.loading = true
    this.api.getAll().subscribe((data: Car[]) => {
      this.cars = data
      this.loading = false
    });
  }
}
