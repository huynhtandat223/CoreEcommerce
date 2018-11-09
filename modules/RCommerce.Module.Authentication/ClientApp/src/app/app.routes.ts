import {HomeComponent} from "./pages/home/home.component";
import { AuthGuard } from '../app/authentication/_guards';

export const appRoutes = [
    {
        path:'',
        redirectTo:'home',
        pathMatch: 'full',
        canActivate: [AuthGuard]
    },
    {
        path: 'home',
        component: HomeComponent,
        canActivate: [AuthGuard]
  },
  {
    path: 'authentication',
    loadChildren: './authentication/authentication.module#AuthenticationModule',
  }
]
