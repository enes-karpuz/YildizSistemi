import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Gezegen } from '../model/gezegen';
import { Uydu } from '../model/uydu';

@Injectable({
  providedIn: 'root'
})
export class YildizSistemleriService {

  constructor(private http: HttpClient) { }

  readonly gezegenBaglantiAdresi = 'https://localhost:7187/api/Gezegen';
  readonly uyduBaglantiAdresi = 'https://localhost:7187/api/Uydu';

  gezegen: Gezegen = new Gezegen();
  uydu: Uydu = new Uydu();

  getirGezegen() {
    return this.http.get(this.gezegenBaglantiAdresi);
  }

  ekleGezegen(gezegen: Gezegen) {
    return this.http.post(this.gezegenBaglantiAdresi, gezegen);
  }

  guncelleGezegen(gezegen: Gezegen) {
    return this.http.put(`${this.gezegenBaglantiAdresi}/${gezegen.id}`, gezegen);
  }

  okuGezegen(id: number) {
    return this.http.get(`${this.gezegenBaglantiAdresi}/${id}`)
  }

  silGezegen(id: number) {
    return this.http.delete(`${this.gezegenBaglantiAdresi}/${id}`);
  }

  getirUydu() {
    return this.http.get(this.uyduBaglantiAdresi);
  }

  ekleUydu(uydu : Uydu) {
    return this.http.post(this.uyduBaglantiAdresi, uydu);
  }

  guncelleUydu(uydu : Uydu) {
    return this.http.put(`${this.uyduBaglantiAdresi}/${uydu.id}`, uydu);
  }

  okuUydu(id: number) {
    return this.http.get(`${this.uyduBaglantiAdresi}/${id}`)
  }

  silUydu(id: number) {
    return this.http.delete(`${this.uyduBaglantiAdresi}/${id}`);
  }

  yenileGezegen(){
    return this.http.get(this.gezegenBaglantiAdresi).toPromise().then();
  }
}
