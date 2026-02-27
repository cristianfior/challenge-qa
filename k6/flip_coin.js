import http from 'k6/http'
import { sleep, check } from 'k6'
import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/latest/dist/bundle.js'
import { textSummary } from 'https://jslib.k6.io/k6-summary/0.1.0/index.js'
import { randomItem } from 'https://jslib.k6.io/k6-utils/1.2.0/index.js';

export const options = {
    stages: [
        {duration: '30s', target: 100},
        {duration: '30s', target: 500},
        {duration: '30s', target: 1000},
        {duration: '30s', target: 500},
        {duration: '30s', target: 100},
        {duration: '30s', target: 0},
    ],
    thresholds: {
        http_req_duration: ['p(95) < 1000'],
        http_req_failed: ['rate < 0.01']
    }
}

export function handleSummary(data) {
  return {
    'k6/flip_coin-report.html': htmlReport(data),
    stdout: textSummary(data, { indent: ' ', enableColors: true })
  }
}

export default function () {
    let bet = randomItem(['heads', 'tails']);
    const url = `https://quickpizza.grafana.com/flip_coin.php?bet=${bet}`
    const res = http.get(url)
    check(res, {
        'status should be 200': (r) => r.status === 200,
        'bet result is visible': (r) => r.body.includes("You won!", "You lost!")
    })
    sleep(1)
}