export interface THeadProps extends React.ComponentProps<'thead'> {
  children: React.ReactNode
}

export const THead: React.FC<THeadProps> = ({ children, ...props }) => {
  return <thead {...props}>{children}</thead>
}
