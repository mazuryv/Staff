import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Position } from './position';

@Injectable()
export class DataService {

  private url;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + "position";
  }

  getPositions() {
    return this.http.get(this.url);
  }

  getPosition(id: string) {
    return this.http.get(this.url + '/' + id);
  }

  createPosition(position: Position) {
    return this.http.post(this.url, position);
  }
  updatePositiont(position: Position) {

    return this.http.put(this.url, position);
  }
  deletePositiont(id: string) {
    return this.http.delete(this.url + '/' + id);
  }
}
