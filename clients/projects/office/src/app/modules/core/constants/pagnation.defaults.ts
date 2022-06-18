import { PageRequest, Sort, SortDirection } from '../models';

export const defaultPageRequest: PageRequest = {
  index: 0,
  size: 10,
  sort: {
    column: 'id',
    direction: SortDirection.Descend
  } as Sort
} as PageRequest;
