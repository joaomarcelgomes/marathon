import { type IconProps } from '@/components/Icon'

export interface InputIconProps
  extends React.InputHTMLAttributes<HTMLInputElement> {
  icon: React.ReactElement<IconProps>
}

export const InputIcon: React.FC<InputIconProps> = (props) => {
  const { icon, ...inputProps } = props

  return (
    <div className="input-group">
      <div className="input-group-text background-3 border-0">{icon}</div>
      <input
        className="form-control form-control-lg background-3 border-0"
        {...inputProps}
      />
    </div>
  )
}
