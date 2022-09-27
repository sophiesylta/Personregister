import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-addPerson',
  templateUrl: './addPerson.component.html'
})
export class AddPersonComponent {
  public person: DTOAddPerson;
  public http: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.person = new DTOAddPerson();
    this.http = http;
    this.baseUrl = baseUrl;
  }

  addPerson()
  {
    this.person = new DTOAddPerson();
    this.http.post(this.baseUrl + 'api/Person', this.person).subscribe(result => { }
      , error => console.error(error));
  }
}

export class DTOAddPerson {
  fornavn: string = "";
  etternavn: string = "";
  personnummer: number = 0;
}
