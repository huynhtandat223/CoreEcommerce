import { Route } from "@angular/router";

export const moduleRoutes: Route[] = [
    {
      path: 'authentication',
      loadChildren: '../authentication/authentication.module#AuthenticationModule',
    }
  ];

