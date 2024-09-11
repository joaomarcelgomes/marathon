import teams from '../data/teams'

export default [
  {
    id: 1,
    name: 'Campeonato Nacional de Programação',
    description:
      'Uma competição nacional para estudantes de Ciência da Computação, focada em algoritmos e estruturas de dados.',
    prize: 'R$ 50.000,00',
    start: '2024-09-15T00:00:00Z',
    end: '2024-09-20T23:59:59Z',
    teams: [teams[0], teams[2]],
  },
  {
    id: 2,
    name: 'Desafio Internacional de Algoritmos',
    description:
      'Competição internacional focada na resolução de problemas complexos usando técnicas avançadas de algoritmos.',
    prize: 'R$ 100.000,00',
    start: '2024-09-01T00:00:00Z',
    end: '2024-09-07T23:59:59Z',
    teams: [teams[1], teams[3]],
  },
]
