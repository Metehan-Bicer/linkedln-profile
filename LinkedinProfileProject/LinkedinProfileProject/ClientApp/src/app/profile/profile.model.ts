export class UserModel {
    public id: number;
    public name: string;
    public surName: string;
    public job: string;
    public districtId: number;
    public cityId: number;
    public districtName: string;
    public cityName: string;
    public company: string;
}
export class CityModel {
    public id: number;
    public cityName: string;
}
export class DistrictModel {
    public id: number;
    public districtName: string;
    public cityId: number;
    public cityName: string;
}

export class ExperienceModel {
    public id: number;
    public userId: number;
    public title: string;
    public companyName: string;
    public sector: string;
    public comment: string;
}
export class EducationModel {
    public id: number;
    public userId: number;
    public school: string;
    public department: string;
    public comment: string;
}
export class AbilitiesModel {
    public id: number;
    public userId: number;
    public abilitiesName: string;
}

export class FileUploadModel {
    public id: number;
    public file: File;
    public userId: number;
    public adress: string;
    public extension: string;
    public contentType: string;
}
export class FileUploadModelImage {
    public id: number;
    public userId: number;
    public adress: string;
    public extension: string;
    public contentType: string;
    public base64: string;

}