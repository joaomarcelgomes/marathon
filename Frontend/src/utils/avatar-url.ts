export default function avatar(name: string) {
  name = name
    .normalize('NFD')
    .replace(/[\u0300-\u036f]/g, '')
    .toLowerCase()
    .replace(/\s+/g, '+')

  return `https://ui-avatars.com/api/?name=${name}&background=random`
}
