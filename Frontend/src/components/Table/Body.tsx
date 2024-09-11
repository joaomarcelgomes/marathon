export interface TBodyProps extends React.ComponentProps<'tbody'> {
  children: React.ReactNode
}

export const TBody: React.FC<TBodyProps> = ({ children, ...props }) => {
  return <tbody {...props}>{children}</tbody>
}
