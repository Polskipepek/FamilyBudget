import * as Yup from 'yup';

Yup.setLocale({
  mixed: {
    default: "Value is invalid",
    required: "Field is required",
    notType: "Value is invalid",
    defined: "Field is required",
  },
  array: {
    min: "Minimum number of elements: ${min}",
    max: "Maximum items: ${max}",
  },
  number: {
    min: "Minimum value must be greater than or equal to ${min}",
    max: "The maximum value must be less than or equal to ${max}",
    lessThan: "Value must be less than ${less}",
    moreThan: "Value must be greater than ${more}",
    integer: "Value must be an integer",
  },
  string: {
    email: "Incorrect email format",
    min: "Minimum characters required: ${min}",
    max: "Maximum characters required: ${max}",
    matches: 'The value must match the format "${regex}"',
  },
});

export default Yup;