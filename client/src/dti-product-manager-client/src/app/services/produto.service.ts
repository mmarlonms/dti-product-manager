import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Http, Response } from '@angular/http';


import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Produto } from '../Models/Produto';
declare var $: any;

@Injectable()
export class ProdutoService {

  private ProdutoesUrl = 'https://localhost:5001/api/v1/produto';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, ) { }

  /** GET Produtoes from the server */
  getProdutos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.ProdutoesUrl)
      .pipe(
        tap(_ => this.log('fetched Produtoes')),
        catchError(this.handleError<Produto[]>('getProdutoes', []))
      );
  }

  getProdutosFilter(filter : string): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.ProdutoesUrl+"/filtrar/"+filter)
      .pipe(
        tap(_ => this.log('fetched Produtoes')),
        catchError(this.handleError<Produto[]>('getProdutosFilter', []))
      );
  }



  //////// Save methods //////////

  /** POST: add a new Produto to the server */
  addProduto(Produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this.ProdutoesUrl, Produto).pipe(
      tap((newProduto: Produto) => this.log(`added Produto w/ id=${newProduto.id}`)),
      catchError(this.handleError<Produto>('addProduto'))
    );
  }

  /** DELETE: delete the Produto from the server */
  deleteProduto(Produto: Produto | number): Observable<Produto> {
    const id = typeof Produto === 'number' ? Produto : Produto.id;
    const url = `${this.ProdutoesUrl}/${id}`;

    return this.http.delete<Produto>(url).pipe(
      tap(_ => this.log(`deleted Produto id=${id}`)),
      catchError(this.handleError<Produto>('deleteProduto'))
    );
  }

  /** PUT: update the Produto on the server */
  updateProduto(produto: Produto): Observable<any> {
    return this.http.put(this.ProdutoesUrl + "/" + produto.id, produto, this.httpOptions).pipe(
      tap(_ => this.log(`updated Produto id=${produto.id}`)),
      catchError(this.handleError<any>('updateProduto'))
    );
  }

  addQntStok(id: number, qnt: number): Observable<any> {
    return this.http.patch(this.ProdutoesUrl + "/" + id + "/adiconarquantidade/" + qnt, this.httpOptions).pipe(
      tap(_ => this.log(`adiconando quantidade do Produto id=${id}`)),
      catchError(this.handleError<any>('updateProduto'))
    );
  }

  removeQntStok(id: number, qnt: number): Observable<any> {
    return this.http.patch(this.ProdutoesUrl + "/" + id + "/removerquantidade/" + qnt, this.httpOptions).pipe(
      tap(_ => this.log(`adiconando quantidade do Produto id=${id}`)),
      catchError(this.handleError<any>('updateProduto'))
    );
  }




  /**
     * Handle Http operation that failed.
     * Let the app continue.
     * @param operation - name of the operation that failed
     * @param result - optional value to return as the observable result
     */
  private handleError<T>(operation = 'operation', result?: T) {

    function showCoreExceptionNotification(message, boddy) {

      $.notify({
        icon: "add_alert",
        message: "<b>" + message + "<b/><br /> " + boddy

      }, {
        type: 'warning',
        timer: 4000,
        placement: {
          from: 'top',
          align: 'right'
        }
      });
    }

    function showExceptionNotification(message, boddy) {

      $.notify({
        icon: "add_alert",
        message: "<b>" + message + "<b/><br /> " + boddy

      }, {
        type: 'danger',
        timer: 4000,
        placement: {
          from: 'top',
          align: 'right'
        }
      });
    }


    return (error: any): Observable<T> => {
      debugger
     
      if(error.status == 400){
        showCoreExceptionNotification(error.error.errors[0].key,error.error.errors[0].message);
      }else{
        showExceptionNotification("Ocorreu um erro não esperado.","Favor verificar junto ao administrador do sistema. LogEntry: "+error.error.logEntryId);
      }

      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private log(message: string) {
    console.log(`ProdutoService: ${message}`);
  }

}

