module.exports.Validator = class Validator {
  constructor() {
    this.rules = [
      {
        fieldLabel: 'byr',
        isValid(fieldValue) {
          let intValue = parseInt(fieldValue);
          return !isNaN(intValue)
            && intValue >= 1920
            && intValue <= 2002
        },
      },
      {
        fieldLabel: 'iyr',
        isValid(fieldValue) {
          let intValue = parseInt(fieldValue);
          return !isNaN(intValue)
            && intValue >= 2010
            && intValue <= 2020
        },
      },
      {
        fieldLabel: 'eyr',
        isValid(fieldValue) {
          let intValue = parseInt(fieldValue);
          return !isNaN(intValue)
            && intValue >= 2020
            && intValue <= 2030
        },
      },
      {
        fieldLabel: 'hgt',
        isValid(fieldValue) {
          const match = fieldValue.match(/(\d+)(in|cm)/);
          let value;
          if (match === null || isNaN(value = parseInt(match[1]))) {
            return false;
          }
          return match[2] === 'in'
            ? value >= 59 && value <= 76
            : value >= 150 && value <= 193
        },
      },
      {
        fieldLabel: 'hcl',
        isValid: fieldValue => /^#[0-9a-f]{6}$/.test(fieldValue.trim()),
      },
      {
        fieldLabel: 'ecl',
        isValid: fieldValue => /^(amb|blu|brn|gry|grn|hzl|oth)$/.test(fieldValue.trim()),
      },
      {
        fieldLabel: 'pid',
        isValid: fieldValue => /^[0-9]{9}$/.test(fieldValue.trim()),
      },
      {
        fieldLabel: 'cid',
        isOptional: true,
        isValid: () => true,
      }
    ]
  }
  validatePassport(passport) {
    if (!passport) {
      return false;
    }
    for (const rule of this.rules) {
      const ppField = passport[rule.fieldLabel];
      if ((ppField === undefined && !rule.isOptional)) {
        return false;
      }
      if (!rule.isValid(ppField)) {
        return false;
      }
    }
    return true;
  }
}