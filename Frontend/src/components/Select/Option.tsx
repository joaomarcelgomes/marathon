export interface OptionProps extends React.ComponentProps<'option'> {
  children?: React.ReactNode
}

export const Option: React.FC<OptionProps> = ({ children, ...props }) => {
  return <option {...props}>{children}</option>
}
