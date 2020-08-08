export interface UsZipCode {
  id: number;
  zipCode: string;
  cityId: number;
  cityName: string;
}

export function initUsZipCode(): UsZipCode {
  return {
    id: -1,
    zipCode: '',
    cityId: -1,
    cityName: '',
  };
}
