import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NONE_TYPE } from '@angular/compiler';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html'
})
export class PersonComponent {
  public personer: DTOPerson[] = [];
  public http: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.http = http;
    this.baseUrl = baseUrl;

    http.get<DTOPerson[]>(baseUrl + 'api/Person').subscribe(result => {
      this.personer = result;
    }, error => console.error(error));
  }

  registrerDodPerson(kallenavn: string) {
    console.log("Registrer dødsfall" + kallenavn);
    let dodsfall = new DTODodsfall();
    dodsfall.kallenavn = kallenavn;
    this.http.post(this.baseUrl + 'api/Dodsfall', dodsfall).subscribe(result => { },
      error => console.error(error));
  }

}


export interface DTOPerson {
  navn: string;
  kallenavn: string;
  erDod: Boolean;
}

export class DTODodsfall {
  personnummer: number = 0;
  kallenavn: string = "";
  dodsarsak: string = "Drept";
  dodsTid: Date = new Date();
}
