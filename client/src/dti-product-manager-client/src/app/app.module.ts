import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from '@angular/router';
import {HttpModule} from '@angular/http';
import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { AppComponent } from './app.component';
import { ProdutoService } from './services/produto.service';
import {MatNativeDateModule} from '@angular/material/core';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { MaterialModules } from './material-module';
import { MatMenuModule} from '@angular/material/menu';
import { DeleteProdutoModalDialog,ProdutoModalDialog,StockProdutoModalDialog } from './product/product-list.component'; 
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

@NgModule({
  imports: [
    MatMenuModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    HttpModule,
    MaterialModules,
    AppRoutingModule,
    MatNativeDateModule
  ],
  entryComponents: [AdminLayoutComponent,DeleteProdutoModalDialog,ProdutoModalDialog,StockProdutoModalDialog],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    DeleteProdutoModalDialog,ProdutoModalDialog,StockProdutoModalDialog
  ],
  providers: [
    ProdutoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

platformBrowserDynamic().bootstrapModule(AppModule);