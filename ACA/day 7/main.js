const { readFileSync } = require('fs');

let rules = {};

readFileSync('./input.txt', 'UTF-8')
    .split('\n')
    .filter(_ => _)
    .forEach(_ => {
        const match =
            Array.from(_.matchAll(/(\d+\s)?([a-z\s]+?)\s(?<!no other )bags?/g))
        let newRule = {};
        match.slice(1).forEach(__ => {
            newRule[__[2]] = parseInt(__[1].trim())
        });
        rules[match[0][2]] = newRule;
    });

let bagCount = 0;

const recur = color => {
    const colorBagProp = rules[color];
    for (let prop in colorBagProp) {
        bagCount += colorBagProp[prop];
        for (let i = 1; i <= colorBagProp[prop]; i++) {
            recur(prop);
        }
    }
};

recur('shiny gold');

console.log(bagCount);