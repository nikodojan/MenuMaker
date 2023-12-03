import { Component } from '@angular/core';
import { SwaggerUIBundle, SwaggerUIStandalonePreset } from "swagger-ui-dist"


@Component({
  selector: 'app-api',
  standalone: true,
  imports: [],
  templateUrl: './api.component.html',
  styleUrl: './api.component.scss'
})

export class ApiComponent {
  ngOnInit(){
    SwaggerUIBundle({
      urls: [
        {
          name: 'V1',
          url: 'https://menumakerapi.azurewebsites.net/swagger/v1/swagger.json'
        }
      ],
      domNode: document.getElementById('swagger-ui'),
      deepLinking: true,
      presets: [SwaggerUIBundle['presets'].apis, SwaggerUIStandalonePreset],
      layout: 'StandaloneLayout'
    });
  }
}
