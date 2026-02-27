import { randomString } from 'https://jslib.k6.io/k6-utils/1.2.0/index.js';

export default function () {
  const randomFirstName = randomString(8);
  console.log(`Hello, my first name is ${randomFirstName}`);

  const randomLastName = randomString(10, `aeioubcdfghijpqrstuv`);
  console.log(`Hello, my last name is ${randomLastName}`);

  const randomCharacterWeighted = randomString(1, `AAAABBBCCD`);
  console.log(`Chose a random character ${randomCharacterWeighted}`);
}