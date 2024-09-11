import classnames from 'classnames'

export interface TableProps extends React.HTMLAttributes<HTMLTableElement> {
  children: React.ReactNode
}

export const Root: React.FC<TableProps> = ({
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
