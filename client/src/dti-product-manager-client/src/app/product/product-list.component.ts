import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProdutoService } from '../services/produto.service';
import { Produto } from '../Models/Produto';
import { MatMenuModule } from '@angular/material/menu';


import 'rxjs/Rx';


@Component({
  selector: 'app-product',
  templateUrl: './views/product-list.component.html'
})

export class ProductListComponent implements OnInit {
  produtos: Produto[];

  constructor(private pordutoService: ProdutoService, public dialog: MatDialog) { }

  ngOnInit() {
    this.getProdutos();
  }

  openEditModal(id: number): void {

    const dialogRef = this.dialog.open(ProdutoModalDialog, {
      width: '60%',
      data: this.produtos.find(x => x.id == id)
    });

    dialogRef.afterClosed().subscribe(result => {
      debugger
      if (result != undefined) {
        console.log(`Dialog result: ${result}`);
        this.pordutoService.updateProduto(result).subscribe(p => {
          this.getProdutos();
        });
      }
    });
  }

  openDeleteModal(id: number): void {

    var produto = this.produtos.find(x => x.id == id);

    const dialogRef = this.dialog.open(DeleteProdutoModalDialog, {
      width: '30%',
      data: produto.nome
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined && result) {
        console.log(`Dialog result: ${result}`);

        this.pordutoService.deleteProduto(id).subscribe(
          p => {
            this.getProdutos();
          }
        );
      }
    });
  }

  openStockModal(id: number, action: string): void {
    const dialogRef = this.dialog.open(StockProdutoModalDialog, {
      width: '60%',
      data: { produto: this.produtos.find(x => x.id == id), action: action },
    });

    dialogRef.afterClosed().subscribe(result => {
      debugger
      if (result != undefined) {
        console.log(`Dialog result: ${result}`);

        if (action == "add") {
          this.pordutoService.addQntStok(id, result).subscribe(
            p => {
              this.getProdutos();
            }
          );
        } else {
          this.pordutoService.removeQntStok(id, result).subscribe(
            p => {
              this.getProdutos();
            }
          );
        }
      }
    });
  }

  openCreateModal(): void {
    const dialogRef = this.dialog.open(ProdutoModalDialog, {
      width: '60%',
      data: new Produto()
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        console.log(`Dialog result: ${result}`);

        this.pordutoService.addProduto(result).subscribe(
          produto => {
            if (produto != undefined)
              this.produtos.push(produto);
          }
        );
      }
    });
  }

  getProdutos(): void {
    this.pordutoService.getProdutos()
      .subscribe(data => this.produtos = data);
  }
}


@Component({
  selector: 'produto-modal-dialog',
  templateUrl: './views/product-modal-dialog.html',
})
export class ProdutoModalDialog {

  constructor(
    public dialogRef: MatDialogRef<ProdutoModalDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Produto) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'delete-produto-modal-dialog',
  templateUrl: './views/delete-product-modal-dialog.html',
})
export class DeleteProdutoModalDialog {

  constructor(
    public dialogRef: MatDialogRef<ProdutoModalDialog>,
    @Inject(MAT_DIALOG_DATA) public data: string) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'stock-product-modal-dialog',
  templateUrl: './views/stock-product-modal-dialog.html',
})
export class StockProdutoModalDialog {
  quantidade;
  constructor(
    public dialogRef: MatDialogRef<ProdutoModalDialog>,
    @Inject(MAT_DIALOG_DATA) public data: { produto: Produto, action: string }) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}