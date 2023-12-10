import { Component } from '@angular/core';

import Chart from 'chart.js/auto';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})

export class IndexComponent {
  public productChart: any;
  public gaugeChart: any;

  currentValue!: number;
  minValue!: number ;
  maxValue!: number ;

  ngOnInit(): void {
    this.createLineChart();
    this.createGaugeChart();

    this.currentValue = 70;
    this.minValue = 50;
    this.maxValue = 100;
  }

  createLineChart() {
    this.productChart = new Chart("ProductChart", {
      type: 'line',
      data: {
        labels: ['5', '4', '3', '2', '1'],
        datasets: [{
          data: [65, 59, 80, 81, 56, 70],
          borderColor: 'rgb(22, 199, 132)',
        }]
      },
      options: {
        maintainAspectRatio: false,
        // responsive: true,
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
    });
  }

  gaugeNeedle = {
    id: 'gaugeNeedle',

    //TODO: Get values from backend
    currentValue: 55,
    minValue: 50,
    maxValue: 100,
    
    afterDatasetsDraw(chart: any, args: any, pluginOptions: any) {
      const { ctx } = chart; 

      ctx.save();

      const xCenter = chart.getDatasetMeta(0).data[0].x;
      const yCenter = chart.getDatasetMeta(0).data[0].y;
      const outerRadius = chart.getDatasetMeta(0).data[0].outerRadius-6;
      const score = (1 - (this.currentValue - this.minValue) / (this.maxValue - this.minValue));
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
      textLabel((score*100), xCenter, yCenter - 30, true, 20, 'botom', 'center', '#666')      
      textLabel(rating, xCenter, yCenter - 10, false, 15, 'botom', 'center', '#666')
   }
  }
  
  createGaugeChart() {
    this.gaugeChart = new Chart("GaugeChart", {
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
        cutout: '85%', 
        elements: {
          arc: {
            borderWidth: 0,
          }
        },
      },
      plugins: [
        this.gaugeNeedle
      ]
    });
  }
}
