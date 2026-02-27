import http from 'k6/http'
import { sleep, check } from 'k6'
import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/latest/dist/bundle.js'
import { textSummary } from 'https://jslib.k6.io/k6-summary/0.1.0/index.js'

export const options = {
    scenarios: {
        onehundred_scenario: {
            executor: 'constant-vus',
            vus: 100,
            duration: '1m'
        },
        fivehundred_scenario: {
            executor: 'per-vu-iterations',
            vus: 500,
            iterations: 50,
            maxDuration: '1m',
        },
        onethousand_scenario: {
            executor: 'shared-iterations',
            vus: 1000,
            iterations: 100000,
            maxDuration: '1m'
        }
    },
    thresholds: {
        http_req_duration: ['p(95) < 1000'],
        http_req_failed: ['rate < 0.01']
    }
}

export function handleSummary(data) {
    return {
        'k6/admin-report.html': htmlReport(data),
        stdout: textSummary(data, { indent: ' ', enableColors: true })
    }
}

export default function () {
    const url = 'https://quickpizza.grafana.com/admin.php';

    const payload = JSON.stringify(
        { login: 'admin', password: '123' }
    );

    const headers = {
        'headers': {
            'Content-Type': 'text/html'
        }
    }

    const res = http.post(url, payload, headers)

    check(res, {
        'status should be 200': (r) => r.status === 200,
        'welcome message is visible': (r) => r.body.includes('Welcome, admin!')
    })
    sleep(1)
}