import classnames from 'classnames'

export interface CheckboxProps extends React.ComponentProps<'input'> {
  id: string
  label?: string
}

export const Checkbox: React.FC<CheckboxProps> = ({
  id,
  label,
  className,
  ...rest
}) => {
  return (
    <div className="custom-checkbox form-check">
      <input
        {...rest}
        id={id}
        type="checkbox"
        className={classnames('form-check-input', className)}
      />
      <label
        htmlFor={id}
        className="form-check-label"
        style={{ display: label ? 'block' : 'none' }}
      >
        {label}
      </label>
    </div>
  )
}
