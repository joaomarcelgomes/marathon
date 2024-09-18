import classnames from 'classnames'

export interface TableProps extends React.ComponentProps<'table'> {
  children: React.ReactNode
}

export const Table: React.FC<TableProps> = ({
  children,
  className,
  ...props
}) => {
  return (
    <table className={classnames('custom-table', className)} {...props}>
      {children}
    </table>
  )
}
