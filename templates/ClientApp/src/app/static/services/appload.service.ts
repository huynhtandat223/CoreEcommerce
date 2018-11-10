import { Injectable, Injector } from "@angular/core";
import { Router } from "@angular/router";

@Injectable()
export class AppLoadService {
    constructor(private injector: Injector) {}

    initializeApp(): Promise<any>{
        const router = this.injector.get(Router);
        return import('../../_shared/modules.json')
            .then((jsonData) => {
                let { modules } = jsonData.default;

                let loadModules = modules.map(moduleJsonData => {

                    return import(`../../${moduleJsonData.folderName}/${moduleJsonData.folderName}.module`)
                        .then(moduleObj => {
                            let temp = moduleObj[moduleJsonData.name];
                            router.config.unshift({
                                path: moduleJsonData.folderName, loadChildren: () => temp
                            });
                        });
                
                });
                return Promise.all(loadModules);
        });

        

    }
}