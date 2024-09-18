import classnames from 'classnames'

export interface SelectProps extends React.ComponentProps<'select'> {
  children?: React.ReactNode
}

export const Select: React.FC<SelectProps> = ({
  children,
  className,
  ...rest
}) => {
  return (
    <div className="custom-select rounded shadow">
      <select
        className={classnames(
          'form-select form-select-lg border-0 bg-none',
          className
        )}
        {...rest}
      >
        {children}
      </select>
    </div>
  )
}
