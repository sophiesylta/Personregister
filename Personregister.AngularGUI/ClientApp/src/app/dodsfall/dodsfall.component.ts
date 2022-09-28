import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-dodsfall',
  templateUrl: './dodsfall.component.html'
})
export class DodsfallComponent {
  public dodsfalls: DTOGetDodsfall[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DTOGetDodsfall[]>(baseUrl + 'api/Dodsfall').subscribe(result => {
      this.dodsfalls = result;
    }, error => console.error(error));
  }
}

interface DTOGetDodsfall {
  fornavn: string;
  etternavn: string;
  dodsarsak: string;
}
