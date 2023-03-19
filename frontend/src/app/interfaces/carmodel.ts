import { Brand } from "./brand";

export interface CarModel {
    id: number;
    name: string;
    brand: Brand;
    brandId: number;
}