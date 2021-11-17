import { Component, OnInit } from '@angular/core';
import { SpareService } from '../spare.service';

@Component({
  selector: 'app-spare-list',
  templateUrl: './spare-list.component.html',
  styleUrls: ['./spare-list.component.scss'],
})
export class SpareListComponent implements OnInit {
  spares!: any[];
  constructor(private spareService: SpareService) {}

  ngOnInit(): void {
    this.getSpares();
  }

  getSpares() {
    this.spareService.getSpares().subscribe(
      (resp: any) => {
        this.spares = resp;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
