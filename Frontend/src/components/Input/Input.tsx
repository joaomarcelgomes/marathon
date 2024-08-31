import classnames from 'classnames'
import { type IconProps } from '@/components/Icon'

export interface InputProps
  extends React.InputHTMLAttributes<HTMLInputElement> {
  icon?: React.ReactElement<IconProps>
}

export const Input: React.FC<InputProps> = (props) => {
  const { icon, className, ...rest } = props

  return (
    <div className="custom-input input-group">
      {icon && (
        <div className="input-group-text background-3 border-0">{icon}</div>
      )}
      <input
        className={classnames(
          'form-control form-control-lg background-3 border-0',
          className
        )}
        {...rest}
      />
    </div>
  )
}
