import users from './users'

export default [
  {
    id: 1,
    name: 'Team Alpha',
    shortName: 'TA',
    imageUrl: 'https://ui-avatars.com/api/?name=team+alpha&background=random',
    createdAt: '2023-05-15T14:30:00Z',
    members: users.slice(0, 3),
  },
  {
    id: 2,
    name: 'Team Beta',
    shortName: 'TB',
    imageUrl: 'https://ui-avatars.com/api/?name=team+beta&background=random',
    createdAt: '2023-11-23T09:15:00Z',
    members: users.slice(3, 6),
  },
  {
    id: 3,
    name: 'Team Gamma',
    shortName: 'TG',
    imageUrl: 'https://ui-avatars.com/api/?name=team+gamma&background=random',
    createdAt: '2023-06-10T10:00:00Z',
    members: users.slice(6, 10),
  },
  {
    id: 4,
    name: 'Team Delta',
    shortName: 'TD',
    imageUrl: 'https://ui-avatars.com/api/?name=team+delta&background=random',
    createdAt: '2023-07-25T15:45:00Z',
    members: users.slice(7, 10),
  },
]
