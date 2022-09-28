import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html'
})
export class PersonComponent {
  public personer: DTOPerson[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DTOPerson[]>(baseUrl + 'api/Person').subscribe(result => {
      this.personer = result;
    }, error => console.error(error));
  }

  registrerDodPerson(kallenavn: string) {
    console.log("Registrer dødsfall" + kallenavn);
    //this.http.post(this.baseUrl + 'api/Person', this.person).subscribe(result => { }
    //  , error => console.error(error));
  }

}


export interface DTOPerson {
  navn: string;
  kallenavn: string;
  erDod: Boolean;
}
