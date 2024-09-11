import React from 'react'
import Sidebar from '@/components/Sidebar'

interface HomeLayoutProps {
  children: React.ReactNode
}

export function HomeLayout({ children }: HomeLayoutProps) {
  return (
    <div className="container-fluid">
      <div className="row">
        <Sidebar />
        <main className="col-sm min-vh-100 overflow-x">{children}</main>
      </div>
    </div>
  )
}
