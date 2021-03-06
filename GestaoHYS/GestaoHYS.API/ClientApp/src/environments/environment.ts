// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: true,
  hmr       : false,
  API:'https://localhost:5001/api/',
  //API_MOCK:'http://localhost:8080/',
  //API: 'http://hysdesentope.com/api/',

  clientes: 'Cliente',
  empresas: 'Empresa',
  parceiros: 'Parceiro',
  usuarios: 'Usuario',
  perfilUsuario: 'PerfilUsuario',
  countries: 'Countries',
  currencies: 'Currencies',
  cultures: 'Cultures',
  customerGroup: 'CustomerGroup',
  paymentMethods: 'PaymentMethods',
  paymentTerms: 'PaymentTerms',
  deliveryTerms: 'DeliveryTerms',
  partyTaxSchemas: 'PartyTaxSchemas',
  partyWithholdingTaxSchemas: 'PartyWithholdingTaxSchemas',
  priceLists: 'PriceLists',
  artigoVendas: 'SalesItem',
  unit: 'Unit',
  assortments: 'Assortments',
  brands: 'Brands',
  brandModels: 'BrandModels',
  invoiceTypes: 'InvoiceTypes',
  invoice: 'SalesInvoice',
  series: 'Series',
  warehouses:'Warehouses',
  itemTaxSchemas: 'ItemTaxSchemas',
  itemWithholdingTaxSchemas: 'ItemWithholdingTaxSchemas',
  titulos: 'titulos',
  ambiente: "dsv"

};


/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
