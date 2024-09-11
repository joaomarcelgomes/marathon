import classnames from 'classnames'
import type { IconProps } from '@/components/Icon'

export interface ButtonProps extends React.HTMLAttributes<HTMLButtonElement> {
  icon?: React.ReactElement<IconProps>
  children?: React.ReactNode
}

export const Button: React.FC<ButtonProps> = ({
  icon,
  children,
  className,
  ...props
}) => {
  return (
    <button className={classnames('btn btn-primary', className)} {...props}>
      {icon}
      {children}
    </button>
  )
}
