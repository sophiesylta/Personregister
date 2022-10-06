import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-addFodsel',
  templateUrl: './addFodsel.component.html'
})
export class AddFodselComponent {
  public fodsel: DTOAddFodsel;
  public http: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.fodsel = new DTOAddFodsel();
    this.http = http;
    this.baseUrl = baseUrl;
  }

  addFodsel() {
    console.log("add fødsel");
    this.http.post(this.baseUrl + 'api/Fodsel', this.fodsel).subscribe(result => { }
      , error => console.error(error));
  }
}

export class DTOAddFodsel {
  personnummerMor: number= 0;
  personnummerFar: number = 0;
  barn: DTOBarn = new DTOBarn;
  fodselTid: Date = new Date();
}
export class DTOBarn {
  fornavn: string = "";
  etternavn: string = "";
  fodselsdato: string = "";
}

