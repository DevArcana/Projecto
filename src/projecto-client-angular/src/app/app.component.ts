import { Component, OnInit } from '@angular/core';
import { ConfigService } from './core/services/config.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'projecto-client-angular';

  constructor(private config: ConfigService) { }

  ngOnInit() {
    console.log(this.config.config);
  }
}
