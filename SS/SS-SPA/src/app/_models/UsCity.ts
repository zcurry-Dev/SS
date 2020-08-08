export interface UsCity {
  id: number;
  name: string;
  closestMajorCityId: number;
  stateId: number;
  majorCity: boolean;
}

export function initUsCity(): UsCity {
  return {
    id: -1,
    name: '',
    closestMajorCityId: -1,
    stateId: -1,
    majorCity: false,
  };
}
