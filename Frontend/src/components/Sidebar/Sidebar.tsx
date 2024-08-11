import React from 'react'
import { Link } from 'react-router-dom'

interface ItemProps {
  href: string
  icon: string
}

const Item: React.FC<ItemProps> = (props) => {
  return (
    <li className="nav-item">
      <Link to={props.href} className="nav-link px-2 py-3">
        <img src={props.icon} width={24} height={24} />
      </Link>
    </li>
  )
}

export const Sidebar: React.FC = () => {
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
            <Item href="/competicoes" icon="/icons/groups.svg" />
            <Item href="/times" icon="/icons/swords.svg" />
          </ul>
          <ul className="nav nav-pills nav-flush flex-sm-column justify-content-sm-end flex-row h-100 px-3 align-items-center">
            <Item href="/perfil" icon="/icons/settings.svg" />
            <Item href="/login" icon="/icons/logout.svg" />
          </ul>
        </nav>
      </div>
    </aside>
  )
}
