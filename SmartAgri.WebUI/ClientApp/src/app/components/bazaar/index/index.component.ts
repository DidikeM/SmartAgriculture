import { AfterViewInit, Component, ElementRef, OnDestroy, QueryList, ViewChildren } from '@angular/core';
import { Router } from '@angular/router';

import Chart from 'chart.js/auto';
import { BazaarService } from 'src/app/services/bazaar.service';
import { ProductDto } from 'src/app/dtos/productdto';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})

export class IndexComponent implements AfterViewInit, OnDestroy {
  products: ProductDto[] = []; 
  isFetching = false;

  @ViewChildren('lineChartCanvas') lineChartCanvas!: QueryList<ElementRef<HTMLCanvasElement>>;
  @ViewChildren('gaugeChartCanvas') gaugeChartCanvas!: QueryList<ElementRef<HTMLCanvasElement>>;
  lineCharts: Chart[] = [];
  gaugeCharts: Chart[] = [];
  
  constructor(private router: Router, private bazaarService: BazaarService) {}

  ngOnInit() {
    this.isFetching = true;
    this.bazaarService.getProducts().subscribe(
      (responseData) => {
        this.isFetching = false;
        console.log("response",responseData)
        this.products = responseData;
        console.log("oldprices",this.products)
      }
    );
  }

  ngAfterViewInit(): void {
    this.bazaarService.getProducts().subscribe(
      (responseData) => {
        this.createCharts();
      }
    );
  }
  
  navigateToProductDetail(productId: number | undefined) {
    if (productId !== undefined) {
      this.router.navigate(['/bazaar/product', productId]);
    }
  }

  createCharts()
  {
    if (this.lineChartCanvas.length != this.products.length)
    {
      console.log(`Line Canvas size ${this.lineChartCanvas.length} and product length ${this.products.length} is not matching!`);
      return;
    }
    if (this.gaugeChartCanvas.length != this.products.length)
    {
      console.log(`Line Canvas size ${this.gaugeChartCanvas.length} and product length ${this.products.length} is not matching!`);
      return;
    }
    this.lineChartCanvas.forEach((canvas: ElementRef<HTMLCanvasElement>, index: number) => {
      this.createLineChart(canvas,this.products[index]);
    });
    this.gaugeChartCanvas.forEach((canvas: ElementRef<HTMLCanvasElement>, index: number) => {
      this.createGaugeChart(canvas,this.products[index]);
    });
  }

  ngOnDestroy(): void {
    this.lineCharts.forEach(lChart => {
      lChart.destroy();
    });
    this.gaugeCharts.forEach(gChart => {
      gChart.destroy();
    });
  }
  
  createLineChart(canvas: ElementRef<HTMLCanvasElement>, product: ProductDto) {
    new Chart(canvas.nativeElement, {
      type: 'line',
      data: {
        labels: ['5', '4', '3', '2', '1'],
        datasets: [{
          data: [product.oldPrices![0], product.oldPrices![1],product.oldPrices![2],product.oldPrices![3],product.oldPrices![4]],
          borderColor: 'rgb(22, 199, 132)',
        }]
      },
      options: {
        maintainAspectRatio: false,
        responsive: false,
        scales: {
          y: {
            display: false,
          },
          x: {
            display: false,
          }
        },
        plugins: {
          legend: {
            display: false, 
          },
          tooltip: {
            enabled: false, 
          }
        }
      }
    })
  }
  
  createGaugeChart(canvas: ElementRef<HTMLCanvasElement>,product:ProductDto) {
    const gaugeNeedle = {
      id:"gaugeNeedle",
      afterDatasetsDraw(chart: any, args: any, pluginOptions: any) {
        const { ctx } = chart; 
        ctx.save();
        const xCenter = chart.getDatasetMeta(0).data[0].x;
        const yCenter = chart.getDatasetMeta(0).data[0].y;
        const outerRadius = chart.getDatasetMeta(0).data[0].outerRadius - 6;
        let minPrice = 0;
        let maxPrice = 0;
        product.oldPrices!.forEach(price => {
          minPrice = Math.min(minPrice, price);
          maxPrice = Math.max(maxPrice, price);
        });
        // const score = Number(((1 - ((product.expectedPrice! - minPrice) / (maxPrice - minPrice))) * 100).toFixed(2).split(".")[0])/100;
        const score = (1 - ((product.expectedPrice! - minPrice) / (maxPrice - minPrice)));
        const angleInRadians: number = score * Math.PI;
        let rating;
  
        if (score < 0.25)
          rating = 'Fear';
        else if (score < 0.5)
          rating = 'Normal';
        else if (score < 0.75)
          rating = 'Greedy';
        else
          rating = 'Extreme Greed'
        
        ctx.translate(xCenter, yCenter);
        
        function textLabel(text: any, x: number, y: number, bold: boolean, fontSize: number, textBaseLine: string, textAlign: string, color: string) {
          let fontString = bold === true ? `bold ${fontSize}px sans-serif` : `${fontSize}px sans-serif`
          ctx.font = fontString;
          ctx.fillStyle = color;
          ctx.textBaseLine = textBaseLine;
          ctx.textAlign = textAlign;
          ctx.fillText(text, x, y);
        }
        
        // Dot
        ctx.beginPath();
        ctx.arc(
          -outerRadius * Math.cos(angleInRadians),
          -outerRadius * Math.sin(angleInRadians), 6, 0, Math.PI * 2, false);
        ctx.fill();
        ctx.restore();
  
        // Text labels
        ctx.beginPath();
        ctx.moveTo(-5, 0);
        ctx.restore();
        textLabel((score * 100).toFixed(2), xCenter, yCenter - 30, true, 20, 'botom', 'center', '#666')      
        textLabel(rating, xCenter, yCenter - 10, false, 15, 'botom', 'center', '#666')
      }
    }
    const gaugeChart = new Chart(canvas.nativeElement, ({
      type: 'doughnut',
      data: {
        labels: ['Red', 'Orange', 'Yellow', 'Light-Green', 'Green'],
        datasets: [{
          data: [50, 50, 50, 50, 50],
          backgroundColor: [
            'rgb(234, 57, 67)',
            'rgb(234, 140, 0)',
            'rgb(243, 212, 47)',
            'rgb(147, 217, 0)',
            'rgb(22, 199, 132)'
          ],
          
          hoverOffset: 4,
          circumference: 180,
          rotation: 270,
          borderWidth: 5,
          borderRadius: 10,
        }]
      },
      options: {
        maintainAspectRatio: false,
        scales: {
          y: {
            display: false,
          },
          x: {
            display: false,
          }
        },
        plugins: {
          legend: {
            display: false,
          },
          tooltip: {
            enabled: false,
          },
        },
        cutout: '88%',
        elements: {
          arc: {
            borderWidth: 0,
          }
        },
      },
      plugins: [
        gaugeNeedle
      ],
    })
    );
  }
  
}
