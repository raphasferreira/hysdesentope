export class Venda {
  id: number;
  imageSrc: string;
  firstName: string;
  lastName: string;
  street: string;
  zipcode: number;
  city: string;
  phoneNumber: string;
  mail: string;
  labels: any;

  constructor(vendas) {
    this.id = vendas.id;
    this.imageSrc = vendas.imageSrc;
    this.firstName = vendas.firstName;
    this.lastName = vendas.lastName;
    this.street = vendas.street;
    this.zipcode = vendas.zipcode;
    this.city = vendas.city;
    this.phoneNumber = vendas.phoneNumber;
    this.mail = vendas.mail;
    this.labels = vendas.labels;
  }

  get name() {
    let name = '';

    if (this.firstName && this.lastName) {
      name = this.firstName + ' ' + this.lastName;
    } else if (this.firstName) {
      name = this.firstName;
    } else if (this.lastName) {
      name = this.lastName;
    }

    return name;
  }

  set name(value) {
  }

  get address() {
    return `${this.street}, ${this.zipcode} ${this.city}`;
  }

  set address(value) {
  }
}
