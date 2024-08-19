import { Link, useLocation } from 'react-router-dom'
import Icon, { type IconProps } from '@/components/Icon'

interface ItemProps {
  href: string
  icon: React.ReactElement<IconProps>
}

const Item: React.FC<ItemProps> = ({ href, icon }) => {
  return (
    <li className="nav-item">
      <Link to={href} className="nav-link px-2 py-3">
        {icon}
      </Link>
    </li>
  )
}

export const Sidebar: React.FC = () => {
  const { pathname } = useLocation()

  const selected = (name: string) => (pathname == name ? '#f00' : '#fff')

  return (
    <aside className="col-sm-auto background-1 sticky-top">
      <div className="d-flex flex-sm-column flex-row gap-sm-5 align-items-center sticky-top h-100">
        <Link to="/" className="d-block mt-sm-3 p-3">
          <img
            src="/marathon-logo.svg"
            alt="Logo Marathon"
            width={32}
            height={32}
          />
        </Link>
        <nav className="d-flex flex-sm-column justify-content-sm-between justify-content-end w-100 h-100">
          <ul className="nav nav-pills nav-flush flex-sm-column flex-row h-100 px-3 align-items-center">
            <Item
              href="/competicoes"
              icon={<Icon.Groups size={24} fill={selected('/competicoes')} />}
            />
            <Item
              href="/times"
              icon={<Icon.Swords size={24} fill={selected('/times')} />}
            />
          </ul>
          <ul className="nav nav-pills nav-flush flex-sm-column justify-content-sm-end flex-row h-100 px-3 align-items-center">
            <Item
              href="/perfil"
              icon={<Icon.Settings size={24} fill={selected('/perfil')} />}
            />
            <Item href="/logout" icon={<Icon.Logout size={24} />} />
          </ul>
        </nav>
      </div>
    </aside>
  )
}
