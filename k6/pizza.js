import http from 'k6/http'
import { sleep, check } from 'k6'
import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/latest/dist/bundle.js'
import { textSummary } from 'https://jslib.k6.io/k6-summary/0.1.0/index.js'
import { randomItem } from 'https://jslib.k6.io/k6-utils/1.2.0/index.js';
import { randomIntBetween } from 'https://jslib.k6.io/k6-utils/1.2.0/index.js';

export const options = {
    stages: [
        { duration: '2m', target: 10000},
        { duration: '1m', target: 0}
    ],
    thresholds: {
        http_req_duration: ['p(95) < 200'],
        http_req_failed: ['rate < 0.01']
    }
}

export function handleSummary(data) {
  return {
    'k6/pizza-report.html': htmlReport(data),
    stdout: textSummary(data, { indent: ' ', enableColors: true })
  }
}

export default function () {
    const url = 'https://quickpizza.grafana.com/api/pizza'

    const headers = {
        'headers': {
            'Content-Type': 'application/json',
            'Authorization': 'Token jc9cBlwBU2GLtfBz'
        }
    }
    
    let customName = 'Pizzariba!'
    let randomTool = randomItem(['Knife','Pizza cutter', 'Scissors'])
    let minNumberOfToppings = randomIntBetween(1, 20)
    let maxNumberOfToppings = randomIntBetween(2, 20)
    let maxCaloriesPerSlice = randomIntBetween(100, 2000)
    let mustBeVegetarian = randomItem([true, false])
    const payload = JSON.stringify(
        {customName: customName, excludedTools: [randomTool], maxCaloriesPerSlice: maxCaloriesPerSlice, maxNumberOfToppings: maxNumberOfToppings, minNumberOfToppings: minNumberOfToppings, mustBeVegetarian: mustBeVegetarian}
    )

    const res = http.post(url, payload, headers);

    check(res, {
        'status should be 200': (r) => r.status === 200
    })
    sleep(1)
}