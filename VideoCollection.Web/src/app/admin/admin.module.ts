import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { DigitalAssetModule } from "./digital-assets";

const declarables = [];
const providers = [];

@NgModule({
    imports: [CommonModule, DigitalAssetModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class AdminModule { }
