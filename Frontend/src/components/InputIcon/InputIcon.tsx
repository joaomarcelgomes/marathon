import React from 'react'

export interface InputIconProps
  extends React.InputHTMLAttributes<HTMLInputElement> {
  icon: string
}

export const InputIcon: React.FC<InputIconProps> = (props) => {
  const { icon, ...inputProps } = props

  return (
    <div className="input-group">
      <div className="input-group-text background-3 border-0">
        <img src={icon} width={16} height={16} />
      </div>
      <input
        className="form-control form-control-lg background-3 border-0"
        {...inputProps}
      />
    </div>
  )
}
