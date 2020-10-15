// 产品
// export class Product {
//     constructor(
//         public sku: string,
//         public name: string,
//         public imageUrl: string,
//         public department: string[],
//         public price: number
//     ) {
//     }
// }

export class Product {
    constructor(
        public name: string,
        public productNumber: string,
        public color: string
    ) { }
}

export class ProductDetail {
    constructor(
        public productId: number,
        public name: string,
        public productNumber: string,
        public color: string,
        public makeFlag: boolean,
        public finishedGoodsFlag: boolean,
        public safetyStockLevel: number,
        public reorderPoint: number,
        public standardCost: number,
        public listPrice: number,
        public size: string,
        public sizeUnitMeasureCode: string,
        public weightUnitMeasureCode: string,
        public weight: number,
        public daysToManufacture: number,
        public productLine: string,
        public sellStartDate: string,
        public sellEndDate: string,
        public style: string,
        public productClass: string,
        public discontinuedDate: string
    ) { }
}

// 产品分类
export class ProductCategory {
    constructor(
        public categoryId: number,
        public categoryName: string) {

    }
}

// 产品子分类
export class ProductSubcategory {
    constructor(
        public subcategoryId: number,
        public categoryName: string) {

    }
}