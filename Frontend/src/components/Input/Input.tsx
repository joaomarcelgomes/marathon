import classnames from 'classnames'
import { type IconProps } from '@/components/Icon'

export interface InputProps
  extends React.InputHTMLAttributes<HTMLInputElement> {
  icon?: React.ReactElement<IconProps>
}

export const Input: React.FC<InputProps> = (props) => {
  const { icon, className, ...rest } = props

  return (
    <div className="custom-input bg-3 input-group shadow">
      {icon && <div className="input-group-text bg-none border-0">{icon}</div>}
      <input
        className={classnames(
          'form-control form-control-lg bg-none border-0',
          className
        )}
        {...rest}
      />
    </div>
  )
}
