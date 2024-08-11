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
        <main className="col-sm p-3 min-vh-100">{children}</main>
      </div>
    </div>
  )
}
