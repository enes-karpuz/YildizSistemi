import { Component, OnInit } from '@angular/core';
import { Uydu } from 'src/app/model/uydu';
import { YildizSistemleriService } from 'src/app/service/yildiz-sistemleri.service';

@Component({
  selector: 'app-uydu',
  templateUrl: './uydu.component.html',
  styleUrls: ['./uydu.component.css']
})
export class UyduComponent implements OnInit {
  
  constructor(private baglantiServisi : YildizSistemleriService){}

  islemBasariliMi: any;
  uydu : Uydu = new Uydu();

  ngOnInit(): void {
    
  }

  ekleUydu(){
    this.baglantiServisi.ekleUydu(this.uydu).subscribe(
      (cevap) => {
        this.islemBasariliMi=cevap;
      }
    )
  }

  sayfaYenile() {
    window.location.reload();
  }
}
