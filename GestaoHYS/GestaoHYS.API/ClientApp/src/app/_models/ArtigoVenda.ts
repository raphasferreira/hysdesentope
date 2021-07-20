import { DateTime } from "luxon";

import { PriceListLine } from "./PriceListLine";


export class ArtigoVenda {
    
    idBaseLocal: string;
    idReferencia: string;
    VersionByte: string;
    locked: boolean;
    itemKey :string ;
    errosIntegracao: string;
    unit : string;
    unitId:string;
    unitDescription: string ;
    itemTaxSchema:string;
    itemTaxSchemaId:string ;
    itemTaxSchemaDescription:string;
    itemType: number;
    itemTypeDescription: string;

    priceListLines: Array<PriceListLine>; 
    incomeAccount:string;
    incomeAccountId: string;
    incomeAccountDescription:string ;
    //salesChannelLines")]
    baseEntityId: string 
    isDraft : boolean;
    isActive : boolean;
    isDeleted: boolean;
    isSystem: boolean;
    createdBy: string;
    createdOn: DateTime;
    modifiedBy:string;
    modifiedOn : DateTime;
    draftId : string;
    state : number;
    isIntegration: boolean; 
    isIntegrated: boolean;
    brand: string;
    brandDescription:string;
    brandId: string;
    brandModel: string;
    brandModelDescription:string;
    brandModelId: string;
    assortment: string;
    assortmentDescription: string;
    assortmentId: string;
    baseUnit: string;
    baseunitId:string;
    baseunitDescription: string ;
    description: string;
    ErrosIntegracao: string;
    complementaryDescription:string;

    itemWithholdingTaxSchema :string;
    itemWithholdingTaxSchemaId : string;
    itemWithholdingTaxSchemaDescription: string;
    constructor(){
        
    }
 
}