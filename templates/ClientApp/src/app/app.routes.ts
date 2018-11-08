import {HomeComponent} from "./pages/home/home.component";
import { moduleRoutes } from "./module.routes";

const defaultRoutes = [
    {
        path:'',
        redirectTo:'home',
        pathMatch:'full'
    },
    {
        path: 'home',
        component: HomeComponent
    }
]

export const appRoutes= [...defaultRoutes, moduleRoutes];