import { Component, OnInit } from '@angular/core';
import { Gezegen } from 'src/app/model/gezegen';
import { YildizSistemleriService } from 'src/app/service/yildiz-sistemleri.service';

@Component({
  selector: 'app-gezegen',
  templateUrl: './gezegen.component.html',
  styleUrls: ['./gezegen.component.css']
})
export class GezegenComponent implements OnInit {
  constructor(private baglantiServisi: YildizSistemleriService) { }

  islemBasariliMi: any;
  gezegen: Gezegen = new Gezegen();

  ngOnInit(): void {

  }

  ekleGezegen() {
    this.baglantiServisi.ekleGezegen(this.gezegen).subscribe(
      (cevap) => {
        this.islemBasariliMi = cevap;
      }
    );
  }

  sayfaYenile() {
    window.location.reload();
  }
}
