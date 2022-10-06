import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-addDodsfall',
  templateUrl: './addDodsfall.component.html'
})
export class AddDodsfallComponent {
  public dodsfall: DTODodsfall;
  public http: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.dodsfall = new DTODodsfall();
    this.http = http;
    this.baseUrl = baseUrl;
  }

  addDodsfall()
  {
    console.log("add dodsfall")
    this.http.post(this.baseUrl + 'api/Dodsfall', this.dodsfall).subscribe(result => { },
      error => console.error(error));
  }

}

export class DTODodsfall
{
  personnummer: number = 0;
  dodsarsak: string = "";
  kallenavn: string = "";
  dodsTid: Date = new Date();
}
