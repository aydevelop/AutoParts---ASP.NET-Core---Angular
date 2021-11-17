import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SpareService } from '../spare.service';

@Component({
  selector: 'app-spare-item',
  templateUrl: './spare-item.component.html',
  styleUrls: ['./spare-item.component.scss'],
})
export class SpareItemComponent implements OnInit {
  spare!: any;

  constructor(
    private activatedRoute: ActivatedRoute,
    private spareService: SpareService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      let id = params.id;

      this.spareService.getSpare(id).subscribe((spare) => {
        this.spare = spare;
      });
    });
  }
}
