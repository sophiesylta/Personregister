import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DTOPerson } from '../person/person.component';


@Component({
  selector: 'app-fodsel',
  templateUrl: './fodsel.component.html'
})
export class FodselComponent {
  public fodsler: DTOGetFodsel[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DTOGetFodsel[]>(baseUrl + 'api/Fodsel').subscribe(result => {
      this.fodsler = result;
    }, error => console.error(error));
  }
}

interface DTOGetFodsel {
  mor: DTOPerson;
  far: DTOPerson;
  barn: DTOPerson;
  fodselsdato: string;
}
