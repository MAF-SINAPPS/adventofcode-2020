const { readFileSync } = require('fs');
const { Validator } = require('./validator');

const validator = new Validator();
let validCount = 0;

readFileSync('./input.txt', 'UTF-8')
    .split('\r\n\r\n')
    .forEach(_ => {
        const passport = {};
        _ = _.replace('\r\n', ' ');
        const propMatches = Array.from(_.matchAll(/([a-z]+):([\S]+)/g));
        for (let match of propMatches) {
            passport[match[1]] = match[2];
        }
        validator.validatePassport(passport) ? validCount++ : null;
    });

console.log(validCount);