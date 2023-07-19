import { Component, OnInit } from '@angular/core';
import { YildizSistemleriService } from '../service/yildiz-sistemleri.service';
import { Gezegen } from '../model/gezegen';
import { Uydu } from '../model/uydu';

@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.css']
})
export class MainpageComponent implements OnInit {

  constructor(private baglantiServisi: YildizSistemleriService) { }

  gezegen: any;
  uydu: any;
  gezegenListesi: any;
  uyduListesi: any;
  islemBasariliMi: any;

  ngOnInit(): void {
    this.getirGezegenListesi();
    this.getirUyduListesi();
  }

  getirGezegenListesi() {
    this.gezegenListesi = this.baglantiServisi.getirGezegen().subscribe(
      (cevap) => {
        this.gezegenListesi = cevap;
      }
    );
  }

  ekleGezegen(gezegen: Gezegen) {
    this.baglantiServisi.ekleGezegen(gezegen).subscribe(
      (cevap) => {
        this.islemBasariliMi = cevap;
      }
    );
  }

  guncelleGezegen(gezegen: Gezegen) {
    this.baglantiServisi.guncelleGezegen(gezegen).subscribe(
      (cevap) => {
        this.islemBasariliMi = cevap;
      }
    );
  }

  okuGezegen(id: number) {
    this.gezegen = this.baglantiServisi.okuGezegen(id).subscribe(
      (cevap) => {
        this.gezegen = cevap;
      }
    );
  }

  silGezegen(id: number) {
    this.baglantiServisi.silGezegen(id).subscribe(
      (cevap) => {
        this.islemBasariliMi = cevap;
      }
    );
  }

  getirUyduListesi() {
    this.uyduListesi = this.baglantiServisi.getirUydu().subscribe(
      (cevap) => {
        this.uyduListesi = cevap;
      }
    );
  }

  ekleUydu(uydu : Uydu) {
    this.uyduListesi = this.baglantiServisi.ekleUydu(uydu).subscribe(
      (cevap) => {
        this.uyduListesi = cevap;
      }
    );
  }

  guncelleUyduListesi(uydu : Uydu) {
    this.uyduListesi = this.baglantiServisi.guncelleUydu(uydu).subscribe(
      (cevap) => {
        this.uyduListesi = cevap;
      }
    );
  }

  okuUyduListesi(id: number) {
    this.uyduListesi = this.baglantiServisi.okuUydu(id).subscribe(
      (cevap) => {
        this.uyduListesi = cevap;
      }
    );
  }

  silUyduListesi(id: number) {
    this.uyduListesi = this.baglantiServisi.silUydu(id).subscribe(
      (cevap) => {
        this.uyduListesi = cevap;
      }
    );
  }
  
  formDoldur(anaKayit: Gezegen) {
    this.baglantiServisi.gezegen = Object.assign({}, anaKayit);
  }
}