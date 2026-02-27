import http from 'k6/http'
import { sleep, check } from 'k6'
import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/latest/dist/bundle.js'
import { textSummary } from 'https://jslib.k6.io/k6-summary/0.1.0/index.js'

export const options = {
    scenarios: {
        onehundred_scenario: {
            executor: 'per-vu-iterations',
            vus: 100,
            iterations: 50,
            maxDuration: '1m'
        },
        fivehundred_scenario: {
            executor: 'ramping-vus',
            startVus: 0,
            stages: [
                {duration: '30s', target: 500},
                {duration: '30s', target: 0}
            ]
        },
        onethousand_scenario: {
            executor: 'constant-vus',
            vus: 1000,
            duration: '1m'
        }
    },
    thresholds: {
        http_req_duration: ['p(95) <= 200'],
        http_req_failed: ['rate <= 0.01']
    }
}

export function handleSummary(data) {
  return {
    'k6/my_messages-report.html': htmlReport(data),
    stdout: textSummary(data, { indent: ' ', enableColors: true })
  }
}

export default function() {
    const url = 'https://quickpizza.grafana.com/my_messages.php'

    const headers = {
        'headers': {
            'Content-Type': 'text/html'
        }
    }

    const res = http.post(url, headers)

    check(res, {
        'status should be 200': (r) => r.status === 200,
        'verify login form visible': (r) => r.body.includes('name="login"', 'name="password"')
    })
    sleep(1)
}