import { Component, OnInit } from '@angular/core';
import * as Chartist from 'chartist';
import { ProdutoService } from '../services/produto.service';
import { Produto } from '../Models/Produto';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  produtos: Array<Produto>;

  now = new Date().toLocaleDateString();
  quantidadeTotalDeProdutos: number;
  valorTotalDoEstoque: number;
  chartView: Chartist.IChartistData;

  constructor(private pordutoService: ProdutoService) { }

  startAnimationForBarChart(chart) {
    let seq2: any, delays2: any, durations2: any;

    seq2 = 0;
    delays2 = 80;
    durations2 = 500;
    chart.on('draw', function (data) {
      if (data.type === 'bar') {
        seq2++;
        data.element.animate({
          opacity: {
            begin: seq2 * delays2,
            dur: durations2,
            from: 0,
            to: 1,
            easing: 'ease'
          }
        });
      }
    });

    seq2 = 0;
  };

  getProdutos(): void {

    this.pordutoService.getProdutos()
      .subscribe(data => {
        this.produtos = data;
        this.produtos = this.produtos.sort( x => x.quantidadeDisponivel);
        this.quantidadeTotalDeProdutos = this.produtos.reduce((a, b) => + a + b.quantidadeDisponivel, 0);
        this.valorTotalDoEstoque = this.produtos.reduce((a, b) => +a + b.valorTotalEmEstoque, 0);
        this.chartView = {
          labels: this.produtos.map(x => x.nome),
          series: [
            this.produtos.map(x => x.quantidadeDisponivel)
          ]
        };
        this.startGraph(this.chartView);
      }
      );
  }

  startGraph(data: Chartist.IChartistData): void {

    var optionswebsiteViewsChart = {
      axisX: {
        showGrid: false
      },
      low: 0,
      high: 100,
      chartPadding: { top: 0, right: 5, bottom: 0, left: 0 }
    };
    var responsiveOptions: any[] = [
      ['screen and (max-width: 640px)', {
        seriesBarDistance: 5,
        axisX: {
          labelInterpolationFnc: function (value) {
            return value[0];
          }
        }
      }]
    ];
    var websiteViewsChart = new Chartist.Bar('#websiteViewsChart', data, optionswebsiteViewsChart, responsiveOptions);

    //start animation for the Emails Subscription Chart
    this.startAnimationForBarChart(websiteViewsChart);
  }

  ngOnInit() {
    this.getProdutos();
  }
}