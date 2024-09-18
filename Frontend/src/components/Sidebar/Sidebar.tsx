import { Link, useLocation } from 'react-router-dom'
import Icon, { type IconProps } from '@/components/Icon'
import useAuth from '@/hooks/use-auth'
import Avatar from '../Avatar'

interface ItemProps {
  href: string
  selected?: boolean
  icon: React.ComponentType<IconProps>
}

const Item: React.FC<ItemProps> = ({ href, selected, icon: Icon }) => {
  return (
    <li className="nav-item">
      <Link to={href} className="nav-link px-2 py-3">
        <Icon size={24} fill={selected ? '#04a33a' : '#fff'} />
      </Link>
    </li>
  )
}

export const Sidebar: React.FC = () => {
  const { pathname } = useLocation()
  const { user } = useAuth()

  return (
    <aside className="sm-sticky-top sm-vh-100 col-sm-auto bg-1">
      <div className="d-flex flex-sm-column flex-row-reverse gap-sm-5 align-items-center sticky-top h-100">
        <Link to="/perfil" className="d-block mt-sm-3 p-3">
          <Avatar url={user.avatar} width={38} height={38} />
        </Link>
        <nav className="d-flex flex-sm-column justify-content-between w-100 h-100">
          <ul className="nav nav-pills nav-flush flex-sm-column flex-row h-100 px-3 align-items-center">
            <Item
              href="/times"
              icon={Icon.Groups}
              selected={pathname.startsWith('/times')}
            />
            <Item
              href="/"
              icon={Icon.Swords}
              selected={pathname === '/' || pathname.startsWith('/competicoes')}
            />
          </ul>
          <ul className="nav nav-pills nav-flush flex-sm-column justify-content-sm-end flex-row h-100 px-3 align-items-center">
            <Item
              href="/perfil"
              icon={Icon.Settings}
              selected={pathname === '/perfil'}
            />
            <Item
              href="/logout"
              icon={Icon.Logout}
              selected={pathname === '/logout'}
            />
          </ul>
        </nav>
      </div>
    </aside>
  )
}
