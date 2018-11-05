import {HomeComponent} from "./pages/home/home.component";

export const appRoutes=[
    {
        path:'',
        redirectTo:'home',
        pathMatch:'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'products',
        loadChildren:'./modules/products/products.module#ProductsModule',
    },
    {
        path: 'others',
        loadChildren:'./pages/others/others.module#OthersModule',
    },
];