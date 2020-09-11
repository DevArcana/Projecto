import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Config from './Config';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  public config: Config | undefined;

  constructor(private http: HttpClient) { }

  async loadConfig(): Promise<void> {
    this.config = await this.http
      .get<Config>('assets/config.json')
      .toPromise();
  }
}
